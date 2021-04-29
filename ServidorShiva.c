#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

	
typedef struct{//Object 
	
	char username[20];

	
}TConnected;

typedef struct{//Lista de ususarios conectados
	
	TConnected conected[100];
	int num;
	
}TListConnected;




TListConnected list;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i=0;
int sockets[100];
	
void GetConnectedUsers(TListConnected *list,char online_users[100]){
	
	int i=0;
	sprintf(online_users,"%d",list->num);
	printf("%d\n",list->num);
	
	//sprintf(online_users,"%s/%s",online_users,list->conected[i].username);//caso i=0
	printf("%s\n",online_users);
	
	while(i<list->num){
		sprintf(online_users,"%s/%s",online_users,list->conected[i].username);
		i++;
	}
}

int AddUser(TListConnected *list, char name[20]){//A帽adir usuario a la lista
	if(list->num==100){
		return -1;//Lista llena
	}
	
	else{
		strcpy(list->conected[list->num].username,name);//A帽adir el nombre del usuario a la lista
		printf("%s,%d\n",list->conected[list->num].username,list->num);
		list->num++;//Incremento de la lista 1 ud
		
		return 0;
	}
}

int DeleteUser(TListConnected *list,char name[20]){//Eliminar usuario de la lista
	
	int i=0;
	int encontrado=0;
	
	while((i<list->num)&&(encontrado==0)){
		if(strcmp(list->conected[i].username,name)==0){
			encontrado=1;
		}
		else{
			i++;
		}
	}
	if(encontrado==1){
		strcpy(list->conected[i].username,list->conected[i+1].username);
		printf("Eliminado: %s,Num Usuarios: %d\n",name,list->num);
		list->num=list->num-1;
		return 0;
	}
	else{
		return -1;//error
	}
}



void Register (char username[20], char password[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [80];
	int i=0;
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error while connecting to database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexion con BBDD
	if (conn==NULL) {
		printf ("Error while trying to connect to database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query (conn, "SELECT * FROM PLAYER");//Realizar consulta a BBDD, mostrar todo contenido PLAYER
	if (err!=0)
	{
		printf ("Error while trying to request %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);//Devuelve Resultado tipo tabla
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);//La primera fila del resultado se almacena en row
	
	i=1;//Para recorrer toda la tabla en un bucle y nos imprima en pantalla el num. de cada fila
	if (row == NULL)
		printf ("No data from request\n");//No hay fila, por tanto la tabla est谩 vac铆a (no hay resultado)
	else
		while (row !=NULL) 
		{
			// las columnas 0 y 1 contienen DNI y nombre 
			printf ("Player %i; Name: %s, Password: %s, Wins: %s\n", i, row[1], row[2], row[3]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);//Cada vez que se ejecuta da la siguiente fila
			i++;
		}
		
		sprintf (consulta,"INSERT INTO PLAYER VALUES(%d,'%s','%s',0,0,0)",i,username,password);//Generamos la sentencia de consulta
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
		
		if (err!=0)
		{
			printf ("Error while adding users to the system %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		err=mysql_query (conn, "SELECT * FROM PLAYER");//Consulta para ver lo que se ha a馻dido
		if (err!=0)
		{
			printf ("Error while trying to get data from database %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		resultado = mysql_store_result (conn); //recogemos el resultado de la nueva consulta 
		row = mysql_fetch_row (resultado);//obtenemos la primera fila
		
		if (row == NULL)
			printf ("No data from request\n");
		
		else
		{
			
			i=1;
			printf("\n");
			
			while (row !=NULL) 
			{
				printf ("Player %i; Name: %s, Password: %s, Wins: %s\n", i, row[1], row[2], row[3]); 
				// obtenemos la siguiente fila
				row = mysql_fetch_row (resultado);//Cada vez que se ejecuta da la siguiente fila
				i++;
			}
			
			mysql_close (conn);
		}
		
}
int Login(char username[20], TListConnected *list,char password[20]){
	
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [100];
	char name_user[20];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error while connecting to database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi贸n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT PLAYER.USERNAME,PLAYER.PASSWORD FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s' ",username,password);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	if (err!=0) {
		printf ("Error while trying to request %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		printf ("No user with this username\n");
		return -1;
	}
	else{
		//row = mysql_fetch_row (resultado);
		printf("-- USER LOGGED: %s PWD: %s --\n",row[0],row[1]);
		return 0;//Si usuario se ha podido loggear
	}
	
	
	mysql_close(conn);
}
float GetRatio(char username[20], char password[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [400];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error while connecting to database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi贸n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT PLAYER.TOTAL_GAMES,PLAYER.WIN_GAMES FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s' ",username,password);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	if (err!=0) {
		printf ("Error while trying to request %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		
		printf ("User not found\n");
		return -1;
	}
	
	float total_wins=atof(row[0]);
	float wins=atof(row[1]);
	printf("Total Wins: %f\n", total_wins);
	printf("Wins: %f Total: %f\n", wins, total_wins);
	mysql_close(conn);
	
	float res;
	
	res = (wins/total_wins);
	printf("el resultado antes de multiplicar por 100: %f\n", res);
	res = res * 100;
	printf("Result: %f\n",res);
	return res;
}
int GetDuration(char username[20],char password[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [300];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error while connecting to database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi贸n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT MAX(GAME.DURATION) FROM (GAME,PLAYER,BRIDGE) WHERE PLAYER.USERNAME = '%s' AND GAME.ID = BRIDGE.ID_GA AND (PLAYER.ID = BRIDGE.ID_PLY1 OR PLAYER.ID = BRIDGE.ID_PLY2)",username);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		
		printf ("User not found\n");
		return -1;
	}
	
	//row = mysql_fetch_row (resultado);
	//printf("Duration of a game is: %s \n", row[0]);
	int tiempo=atoi(row[0]);
	printf("Game Duration: %d\n", tiempo);
	mysql_close(conn);
	
	return tiempo;
}
int ConsultaSergi(char username[20], char password[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [100];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error al crear la conexi贸n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi贸n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT PLAYER.WIN_GAMES FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s' ",username,password);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		
		printf ("No hay nadie con ese nombre\n");
		return -1;
	}
	
	//row = mysql_fetch_row (resultado);
	printf("EL total de Wins es: %s\n", row[0]);
	int wins=atoi(row[0]);
	mysql_close(conn);
	return wins;
}
void *AtenderCliente (void *socket)
{
	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char buff[512];
	char buff2[512];
	int ret;
	
	int kill=0;//Para desconectar socket
	
	while(kill==0) //Bucle de demanda de servicios
	{
		
		ret=read(sock_conn,buff, sizeof(buff));
		printf ("Data received\n");
		
		
		buff[ret]='\0';//Se a帽ade marca de fin de l铆ne de la string
		
		printf ("Packet received: %s\n",buff);
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);//Extracci贸n de c贸digo del servicio
		char username[20];
		char password[20];
		
		if(codigo==0){
			
			int res=DeleteUser(&list,username);
			if(res==0){
				printf("Deleted from list\n");
				//Notificacion
					char online_users[300];
					printf("entrada servicio\n");
					GetConnectedUsers(&list,online_users);
					printf("Online users: %s\n",online_users);
					
					if(online_users==NULL){
						printf("No users connected at this moment\n");
					}
					else
					{
						char notificacion[100];
						sprintf(notificacion,"6/%s",online_users);
						
						int j=0;
						while(j<i){
							write (sockets[j],notificacion, strlen(notificacion));
							j++;
						}
					}
				
			}
			else{
				printf("Couldn't deleted from list\n");
			}
			kill=1;//Acabar bucle(Usuario desconectado)
		}
		
		if((codigo!=0)&&(codigo!=6)){//Extracci贸n de info
			p = strtok( NULL, "/");  
			strcpy(username,p);
			p = strtok( NULL, "/");
			strcpy(password,p);
			
			printf ("Username: %s, Password: %s\n",username,password);
			
		}
		
		if (codigo ==1){//Registrarse a la BBDD
			Register(username,password);//Funci贸n de registro a la BBDD
			strcpy(buff2,"1/Done");
		}		
		
		if (codigo ==2){//Login
			int res;
			
			pthread_mutex_lock(&mutex);//No interrumpir
			res=Login(username,&list,password);
			pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
			
			if(res==0){//Existe usuario en el sistema
				
				pthread_mutex_lock(&mutex);//No interrumpir
				int user_added = AddUser(&list,username);//A馻dir usuario lista conectados
				pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
				
				if(user_added==0){
					printf("User %s added to list correctly\n",username);
					strcpy(buff2,"2/Done");
				}
				else{
					printf("Error adding user to the list\n");
				}
			}
			
			else{
				printf("No user with this username\n");//No existe usuario en el sistema
				strcpy(buff2,"2/Fail");
			}
			
		}		
		if (codigo == 3)//Siguiente servicio
		{
			printf ("paso3\n");
			int res1;
			res1 = GetDuration(username,password);
			printf("el valor es: %d \n", res1);
			sprintf(buff2,"3/el tiempo maximo de una partida es: %d", res1);
		}
		if (codigo ==4)
		{//Siguiente servicio
			
			float ratio;
			ratio=GetRatio(username,password);
			if(ratio > 0){
				sprintf(buff2,"4/%f,",ratio);
				//strcpy(buff2,"Done,");
			}
			else
			   strcpy(buff2,"4/Fail,");
			
		}
		
		if (codigo ==5)
		{//Siguiente servicio
			
			int res2 = ConsultaSergi(username,password);
			sprintf(buff2,"5/%d,",res2);
		}
		
		if ((codigo ==1)|(codigo ==2)|(codigo ==3)|(codigo ==4)|(codigo ==5))//Notificacion
		{//Servicio de clientes online
			
			char online_users[300];
			printf("entrada servicio\n");
			GetConnectedUsers(&list,online_users);
			printf("Online users: %s\n",online_users);
			
			if(online_users==NULL){
				printf("No users connected at this moment\n");
			}
			else
			{
				char notificacion[100];
				sprintf(notificacion,"6/%s",online_users);
				
				int j=0;
				while(j<i){
					write (sockets[j],notificacion, strlen(notificacion));
					j++;
				}
			}
		}
		if(codigo!=0){
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
		}
		// Se acabo el servicio para este cliente
		
	}
	close(sock_conn); //Cerrar conexi贸n
}



int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];
	

	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)//Abrimos Socket
		printf("Error building socket");

		
	memset(&serv_adr, 0, sizeof(serv_adr));// Inicializa a cero el serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(50077);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Bind Error");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Listening Error");
	
	pthread_t thread[100];
	
	for(;;)
	{
		printf ("Listening...\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("User connected\n");
		printf("%d\n",sock_conn);
		
		sockets[i] = sock_conn;
		
		//sock_conn es el socket que usaremos para este cliente
		
		//crear thead y decirle lo que tiene que hacer
		printf("Entrada\n");
		pthread_create (&thread[i], NULL, AtenderCliente,&sockets[i]);
		i++;
	}
}

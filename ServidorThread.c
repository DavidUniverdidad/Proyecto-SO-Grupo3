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
	
void GetConnectedUsers(TListConnected *list,char online_users[300]){
	
	printf("Entrada funcion\n");
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

int AddUser(TListConnected *list, char name[20]){//Añadir usuario a la lista
	if(list->num==100){
		return -1;//Lista llena
	}
	
	else{
		strcpy(list->conected[list->num].username,name);//Añadir el nombre del usuario a la lista
		printf("%s,%d\n",list->conected[list->num].username,list->num);
		list->num++;//Incremento de la lista 1 ud
		printf("%d actualizado\n",list->num);
		
		return 0;
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexion con BBDD
	if (conn==NULL) {
		printf ("Error while trying to connect to database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query (conn, "SELECT * FROM PLAYER");//Realizar consulta a BBDD, mostrar todo contenido PLAYER
	if (err!=0)
	{
		printf ("Error while trying to get data from database %u %s\n", mysql_errno(conn), mysql_error(conn));
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
		printf ("No data from request\n");//No hay fila, por tanto la tabla está vacía (no hay resultado)
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
		
		err=mysql_query (conn, "SELECT * FROM PLAYER");//Consulta para ver lo que se ha a�adido
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
	if (conn==NULL) {
		printf ("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT PLAYER.USERNAME,PLAYER.PASSWORD FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s' ",username,password);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
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
		printf ("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
	if (conn==NULL) {
		printf ("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT PLAYER.TOTAL_GAMES,PLAYER.WIN_GAMES FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s' ",username,password);//Generamos la sentencia de consulta
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
int ConsultaDavid(char username[20],char password[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [300];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
	if (conn==NULL) {
		printf ("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
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
		
		printf ("No hay nadie con ese nombre\n");
		return -1;
	}
	
	//row = mysql_fetch_row (resultado);
	printf("La duracion: %s \n", row[0]);
	int tiempo=atoi(row[0]);
	printf("La duracion convertida en un integer es: %d\n", tiempo);
	mysql_close(conn);
	printf("La duracion convertida en un integer es antes del return %d\n", tiempo);
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
		printf ("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
	if (conn==NULL) {
		printf ("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
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
	TListConnected list;
	list.num=0;
	
	int kill=0;//Para desconectar socket
	
	while(kill==0) //Bucle de demanda de servicios
	{
		
		ret=read(sock_conn,buff, sizeof(buff));
		printf ("Data received\n");
		
		
		buff[ret]='\0';//Se añade marca de fin de líne de la string
		
		printf ("Packet received: %s\n",buff);
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);//Extracción de código del servicio
		char username[20];
		char password[20];
		
		if(codigo==0){
			kill=1;//Acabar bucle
		}
		
		if((codigo!=0)&&(codigo!=6)){//Extracción de info
			p = strtok( NULL, "/");  
			strcpy(username,p);
			p = strtok( NULL, "/");
			strcpy(password,p);
			
			printf ("Username: %s, Password: %s\n",username,password);
			
		}
		
		if (codigo ==1){//Registrarse a la BBDD
			Register(username,password);//Función de registro a la BBDD
			strcpy(buff2,"Done");
		}		
		
		else if (codigo ==2){//Login
			int res;
			res=Login(username,&list,password);
			
			if(res==0){//Existe usuario en el sistema
				
				int user_added = AddUser(&list,username);//A�adir usuario lista conectados
				
				if(user_added==0){
					printf("User %s added to list correctly\n",username);
					strcpy(buff2,"Done");
				}
				else{
					printf("Error adding user to the list\n");
				}
			}
			
			else{
				printf("No user with this username\n");//No existe usuario en el sistema
			}
			
		}		
		else if (codigo == 3)//Siguiente servicio
		{
			printf ("paso3\n");
			int res1;
			res1 = ConsultaDavid(username,password);
			printf("el valor es: %d \n", res1);
			sprintf(buff2,"el tiempo maximo de una partida es: %d", res1);
		}
		else if (codigo ==4)
		{//Siguiente servicio
			
			float ratio;
			ratio=GetRatio(username,password);
			if(ratio > 0){
				sprintf(buff2,"%f,",ratio);
				//strcpy(buff2,"Done,");
			}
			else
			   strcpy(buff2,"Fail,");
			
		}
		
		else if (codigo ==5)
		{//Siguiente servicio
			
			int res2 = ConsultaSergi(username,password);
			sprintf(buff2,"%d,",res2);
		}
		
		else if (codigo ==6)
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
				strcpy(buff2,online_users);
			}
		}
		if(codigo!=0){
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
		}
		// Se acabo el servicio para este cliente
		
	}
	close(sock_conn); //Cerrar conexión
}
int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];
	TListConnected list;
	list.num=0;
	

	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)//Abrimos Socket
		printf("Error building socket");

		
	memset(&serv_adr, 0, sizeof(serv_adr));// Inicializa a cero el serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9093);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Bind Error");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Listening Error");
	
	int i;
	int socket[100];
	pthread_t thread[100];
	
	for(;;)
	{
		printf ("Listening...\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("User connected\n");
		
		socket[i] = sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		//crear thead y decirle lo que tiene que hacer
		pthread_create (&thread[i], NULL, AtenderCliente,&socket[i]);
	}
}

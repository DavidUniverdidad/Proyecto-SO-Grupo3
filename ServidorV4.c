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
	int socket;

	
}TConnected;

typedef struct{//Lista de ususarios conectados
	
	TConnected conected[100];
	int num;
	
}TListConnected;



TListConnected list;

typedef struct{
	int id;
	int oc;
	TConnected usuarios_partida[4];
	
}TPartida;

typedef TPartida TTabla[100];
TTabla tabla_partidas;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i=0;
int partida=0;
int jugador=0;
int sockets[100];

/*void InicioTabla(){//Se inicializa la tabla de partidas, casillas vac�as = -1
	int i=0;
	while(i<100){
		tabla_partidas[i].oc=-1;
		i++;
	}
}
*/
int AddUsersGame(TTabla *tabla_partidas,char usernames[100]){//A�adir usuarios a la tabla
	printf("Entrada a A�adir Usuarios Juego\n");
	int i=0;
	int encontrado=0;
	char user[20];
	int num_partida;
	
	printf("var Partida: %d\n",partida);
	
	/*while((i<partida+1)&&(encontrado==0)){//Buscar partida libre en tabla (no completa)
		
		if(tabla_partidas[i]->oc==-1){
			encontrado=1;
			tabla_partidas[i]->oc=0;
				
			printf("Encontrado espacio libre en pos partida num: %d\n",i);
		}
		else{
			i++;
		}
		
	}	*/
		
		if(encontrado==0){//Cambiar a 1 para poner como antes
			int k=0;
			tabla_partidas[partida]->id=partida;//cambiar a i. CAMBIAR PARTIDA POR i
			printf("id partida: %d, para pos: %d\n",tabla_partidas[partida]->id,partida);
			printf("---\n");
			//num_partida=i;//id partida
			
			while(k<partida){
				
				printf("id partida: %d, para pos: %d\n",tabla_partidas[k]->id,k);
				//num_partida=i;//id partida
				
				k++;
			}
			
			char *p = strtok(usernames,"/");
			strcpy(user,p);//Obtener username
			int socket=GetUserSocket(&list,user);//Obtener socket
			
			strcpy(tabla_partidas[partida]->usuarios_partida[jugador].username,user);
			tabla_partidas[partida]->usuarios_partida[jugador].socket=socket;
			
			printf("(Jugador %d) Usuario: %s, Socket: %d, ID Partida: %d\n",jugador,tabla_partidas[partida]->usuarios_partida[jugador].username,tabla_partidas[partida]->usuarios_partida[jugador].socket,tabla_partidas[partida]->id);
			
			jugador++;
			
			while(p!=NULL){
				
			p = strtok(NULL,"/");
			
			if(p!=NULL){
				strcpy(user,p);//Obtener username
				socket=GetUserSocket(&list,user);//Obtener socket
				
				strcpy(tabla_partidas[partida]->usuarios_partida[jugador].username,user);
				tabla_partidas[partida]->usuarios_partida[jugador].socket=socket;
				printf("(Jugador %d) Usuario: %s, Socket: %d, ID Partida: %d\n",jugador,tabla_partidas[partida]->usuarios_partida[jugador].username,tabla_partidas[partida]->usuarios_partida[jugador].socket,tabla_partidas[partida]->id);
				
				jugador++;
				}
			}
			printf("\n");
			return partida;//Ha a�adido usuario con �xito
	
	}
		
		else{
			return -1;//Error
		}
}


int DeleteUsersGame(char username[20],int num_partida){//Eliminar usuarios de la tabla
	printf("Entrada a Eliminar Usuarios Juego\n");
	int i=0;
	char user[20];
	int encontrado=0;
	
	while((i<partida+1)&&(encontrado==0)){
		
		if(tabla_partidas[i].id==num_partida){
			encontrado=1;
			printf("Encontrada partida\n");
		}
		
		i++;
	}
	
	int j=0;
	printf("Usuario a Eliminar: %s; Partida escogida %d; Valor i: %d\n",username,i,num_partida);
	printf("Entrada en bucle\n");
	if (encontrado==1){//En teor�a solo puede haber m�ximo de 4 jugadores!
		while(j<4){

			printf("Usuario: %s\n",tabla_partidas[i-1].usuarios_partida[j].username);
			if(strcmp(tabla_partidas[i-1].usuarios_partida[j].username,username)==0){//Buscar en esa partida el nombre
				strcpy(tabla_partidas[i-1].usuarios_partida[j].username," ");//Poner NULL??
				printf("Usuario: %s\n",tabla_partidas[i-1].usuarios_partida[j].username);
			}
			j++;
		}
		printf("Salida funci�n eliminar\n");
	}
	return 0;
	
}

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

int AddUser(TListConnected *list, char name[20],int socket_num){//Añadir usuario a la lista
	if(list->num==100){
		return -1;//Lista llena
	}
	
	else{
		strcpy(list->conected[list->num].username,name);//Añadir el nombre del usuario a la lista
		list->conected[list->num].socket=socket_num;
		printf("%s,%d ; numero socket: %d\n",list->conected[list->num].username,list->num,list->conected[list->num].socket);
		list->num++;//Incremento de la lista 1 ud
		
		return 0;
	}
}

int GetUserSocket(TListConnected *list, char username[20]){
	int i=0;
	int encontrado=0;
	
	while((i<list->num)&&(encontrado!=1)){
		if(strcmp(list->conected[i].username,username)==0){
			encontrado=1;
		}
		
		i++;
	}
	
	if(encontrado==1){
		int sock_num;
		sock_num = list->conected[i-1].socket;
		printf("socket dest: %d\n",sock_num);
		return sock_num;
	}
	else{
		return -1;
	}
}

int GetUserName(TListConnected *list, int socket, char username[20]){
	
	int i=0;
	int encontrado=0;
	
	while((i<list->num)&&(encontrado!=1)){
		if(list->conected[i].socket==socket){
			encontrado=1;
		}
		
		i++;
	}
	if(encontrado==1){
		
		sprintf(username,list->conected[i-1].username);
		printf("Usuario que transmite mensaje: %s\n",username);
		return 1;
	}
	else{
		return -1;
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexion con BBDD
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
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
		printf ("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
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
	
	char username[20];
	char password[20];
	char users_to_game_list[100];
	
	int kill=0;//Para desconectar socket
	
	while(kill==0) //Bucle de demanda de servicios
	{
		
		ret=read(sock_conn,buff, sizeof(buff));
		printf ("Data received\n");
		
		
		buff[ret]='\0';//Se añade marca de fin de líne de la string
		
		printf ("Packet received: %s\n",buff);
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);//Extracción de código del servicio
		
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
		
		if((codigo!=0)&&(codigo!=7)&&(codigo!=8)){//Extracción de info
			p = strtok( NULL, "/");  
			strcpy(username,p);
			p = strtok( NULL, "/");
			strcpy(password,p);
			
			printf ("Username: %s, Password: %s\n",username,password);
			
		}
		
		if(codigo==7){//Se genera la string necesaria para enviar todos los nombres de jugadores a la funcion AddUsersGame
			printf("Entrada pre-servicio 7\n");
			p = strtok( NULL, "/"); 
			strcpy(users_to_game_list,p);
			printf("Primera etapa\n");
			
			while(p!=NULL){
				p = strtok( NULL, "/");
				if(p!=NULL){
					sprintf(users_to_game_list,"%s/%s",users_to_game_list,p);
				}
			}
			printf("Final etapa\n");
			
			printf("Variable users_to_game_list: %s\n",users_to_game_list);
		}
		
		if (codigo ==1){//Registrarse a la BBDD
			Register(username,password);//Función de registro a la BBDD
			strcpy(buff2,"1/Done");
		}		
		
		if (codigo ==2){//Login
			int res;
			
			pthread_mutex_lock(&mutex);//No interrumpir
			res=Login(username,&list,password);
			pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
			
			if(res==0){//Existe usuario en el sistema
				
				pthread_mutex_lock(&mutex);//No interrumpir
				int user_added = AddUser(&list,username,sock_conn);//A�adir usuario lista conectados
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
		
		if (codigo ==7)
		{//Invitaci�n a partida
			printf("Entrada a servicio 7\n");
			int socket_dest;
			char username_dest[20];
			char username_origin[20];
			int res;
			char users[100];
			int num_partida;
			
			sprintf(username_dest,users_to_game_list);
			printf("username_list dest ok: %s\n",username_dest);
			
			//socket_dest=GetUserSocket(&list,username_dest);//obtener su socket destino
			
			res=GetUserName(&list,sock_conn,username_origin);//Obtener nombre usuario origen
			
			if(res!=-1){
				strcpy(username,username_origin);//pendiente ???
			}
			
			//sprintf(buff2,"7/%s",username_origin);//Crear paquete
			//printf("%s envia invitacion a %s; Formato: %s\n",username_origin,username_dest,buff2);
			
			sprintf(users,"%s/%s/",users_to_game_list,username_origin);//Variable users_to_game_list contiene solo los invitados
			printf("Creado string nombres de partida\n");
			printf("variable users: %s\n",users);//variable users contiene TODOS los jugadores que formaran la partida
			
			pthread_mutex_lock(&mutex);//No interrumpir
			num_partida=AddUsersGame(&tabla_partidas,users);//A�adir todos los usuarios
			pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
			
			jugador=0;//Resetear var global conteo jugadores/partida
			partida++;//Revisar
			printf("Incremento partida, nuevo valor: %d\n",partida);
			
			if(num_partida!=-1){
				printf("Usuarios a�adidos a la partida\n");
			}
			else{
				printf("Usuarios NO a�adidos a partida\n");
			}
			
			char username_invitado[20];
			int socket_invitado;
			char mensaje[80];
			
			sprintf(mensaje,"7/%s/%d",username_origin,num_partida);//Crear mensaje a enviar
			
			p = strtok(users_to_game_list,"/");
			strcpy(username_invitado,p);//Obtener username
			
			printf("var username_invitado: %s\n",username_invitado);
			socket_invitado=GetUserSocket(&list,username_invitado);//Obtener socket
			
			write (socket_invitado,mensaje, strlen(mensaje));
			printf("Mensaje enviado\n");
			
			while(p!=NULL){
				printf("Entrada bucle\n");
				p = strtok(NULL,"/");
				
				if(p!=NULL){
					
					strcpy(username_invitado,p);//Obtener username
					printf("var username_invitado: %s\n",username_invitado);
					socket_invitado=GetUserSocket(&list,username_invitado);//Obtener socket

					write (socket_invitado,mensaje, strlen(mensaje));
					printf("Enviado\n");
				}
			}
			/*int j=0;
			while(j<i){
				write (socket_dest,notificacion, strlen(notificacion));
				j++;
			}
			*/
			
			//MOSTRAR EN PANTALLA ESTADO TABLA
			int p=0;
			int j=0;
			printf("Nmero partidas creadas: %d\n",partida);
			while(p<partida){
				
				while(j<4){
					printf("%d) Partida %d, Jugador: %s\n",p,tabla_partidas[p].id,tabla_partidas[p].usuarios_partida[j].username);
					j++;
				}
				printf("\n");
				j=0;
				p++;
				
			}
		}
		
		if (codigo ==8)
		{//Aceptar petici�n
			printf("\n");
			printf("Entrada a servicio 8\n");
			char username_dest[20];
			int socket_dest;
			char respuesta[20];
			char username_origin[20];
			int res;
			int num_partida;
				
			p = strtok(NULL, "/");  //extraer nombre usuario destino
			strcpy(username_dest,p);
			printf("username dest ok: %s\n",username_dest);
			socket_dest=GetUserSocket(&list,username_dest);//obtener su socket
			
			p = strtok(NULL, "/");  //extraer respuesta
			strcpy(respuesta,p);
			printf("Respuesta: %s\n",respuesta);
			
			p = strtok(NULL, "/");  //extraer num partida
			num_partida=atoi(p);
			printf("Aceptacion al num partida: %d\n",num_partida);
			
			res=GetUserName(&list,sock_conn,username_origin);
			if(res!=-1){
				strcpy(username,username_origin);
			}
			
			if(strcmp(respuesta,"SI")==0){
				
				sprintf(buff2,"8/%s/%s/%d",username_origin,respuesta,num_partida);//Crear paquete
				printf("%s envia respuesta de la peticion a %s; Formato: %s\n",username_origin,username_dest,buff2);
				write (socket_dest,buff2, strlen(buff2));//Enviar mensaje al socket destinatario
				printf("Enviado\n");
				
				//pthread_mutex_lock(&mutex);//No interrumpir
				//AddUsersGame(username_origin,sock_conn);//A�adir emisor aceptar a la tabla de partidas
				//pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
				
			}
			if(strcmp(respuesta,"NO")==0){
				
				pthread_mutex_lock(&mutex);//No interrumpir
				int res=DeleteUsersGame(username_origin,num_partida);
				pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
				if(res==0){
					
					sprintf(buff2,"8/%s/%s/%d",username_origin,respuesta,num_partida);//Crear paquete
					printf("%s envia aceptacion invitacion a %s; Formato: %s\n",username_origin,username_dest,buff2);
					write (socket_dest,buff2, strlen(buff2));//Enviar mensaje al socket destinatario
					printf("Enviado\n");
				}
				
			}
			
			int p=0;
			int j=0;
			printf("Nmero partidas creadas: %d\n",partida);
			while(p<partida){
				while(j<4){
					printf("Partida %d, Jugador: %s\n",tabla_partidas[p].id,tabla_partidas[p].usuarios_partida[j].username);
					j++;
				}
				printf("\n");
					j=0;
					p++;
					
			}
			
		//A�adir en tabla de partida este usuario y tx + sus sockets
			
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
		if((codigo!=0)&&(codigo!=7)&&(codigo!=8)){
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

	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)//Abrimos Socket
		printf("Error building socket");

		
	memset(&serv_adr, 0, sizeof(serv_adr));// Inicializa a cero el serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9089);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Bind Error");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Listening Error");
	
	pthread_t thread[100];
	
	//InicioTabla();
	
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
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

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
		printf ("Error al crear la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);//Iniciar conexión con BBDD
	if (conn==NULL) {
		printf ("Error al inicializar la conexión: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query (conn, "SELECT * FROM PLAYER");//Realizar consulta a BBDD, mostrar todo contenido PLAYER
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
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
		printf ("No se han obtenido datos en la consulta\n");//No hay fila, por tanto la tabla está vacía (no hay resultado)
	else
		while (row !=NULL) {
			// las columnas 0 y 1 contienen DNI y nombre 
			printf ("Player %i; Name: %s, Password: %s, Wins: %s\n", i, row[1], row[2], row[3]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);//Cada vez que se ejecuta da la siguiente fila
			i++;
	}
		
		sprintf (consulta,"INSERT INTO PLAYER VALUES(%d,'%s','%s',0,0,0)",i,username,password);//Generamos la sentencia de consulta
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
		
		if (err!=0) {
			printf ("Error al realizar cambios en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		err=mysql_query (conn, "SELECT * FROM PLAYER");//Consulta para ver lo que se ha añadido
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		resultado = mysql_store_result (conn); //recogemos el resultado de la nueva consulta 
		row = mysql_fetch_row (resultado);//obtenemos la primera fila
		
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta\n");
		
		else{
			
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
void Login(char username[20], char password[20]){
	
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
	
	sprintf (consulta,"SELECT PLAYER.USERNAME,PLAYER.PASSWORD FROM PLAYER WHERE USERNAME='%s' AND PASSWORD='%s' ",username,password);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No hay nadie con ese nombre\n");
	else{
		//row = mysql_fetch_row (resultado);
		printf("-- USER LOGGED: %s PWD: %s --\n",row[0],row[1]);
	}
	
	
	mysql_close(conn);
}
float Ratio(char username[20], char password[20])
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
	
	//row = mysql_fetch_row (resultado);
	printf("EL toal que me interesa Wins: %s Total: %s \n", row[1], row[0]);
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
	printf("EL toal que me interesa Wins: %s Total: %s \n", row[0]);
	int wins=atoi(row[0]);
	mysql_close(conn);
	return wins;
}
/*
int ConsultaDavid (char username[20])
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int page_id = 0;
	char consulta [80];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "trivial",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	// consulta SQL para obtener una tabla con todos los datos
	// de la base de datos
	err=mysql_query (conn, "SELECT * FROM PLAYER");
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	// En una fila hay tantas columnas como datos tiene una
	// persona. En nuestro caso hay tres columnas: dni(row[0]),
	// nombre(row[1]) y edad (row[2]).
	int i=1;
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else
		while (row !=NULL) {
			// las columnas 0 y 1 contienen DNI y nombre 
			printf ("Player %i; Name: %s, Password: %s, Wins: %s\n", i, row[1], row[2], row[3]);
			// obtenemos la siguiente fila
			row = mysql_fetch_row (resultado);
			i++;
	}

		// construimos la consulta SQL
		sprintf (consulta,"SELECT MAX(GAME.DURATION) FROM (GAME,PLAYER,BRIDGE) WHERE PLAYER.USERNAME = '%s' AND GAME.ID = BRIDGE.ID_GA AND (PLAYER.ID = BRIDGE.ID_PLY1 OR PLAYER.ID = BRIDGE.ID_PLY2)",username); 
		// hacemos la consulta 
		err=mysql_query (conn, consulta); 
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//recogemos el resultado de la consulta 
		resultado = mysql_store_result (conn);
		printf("el resultado es: %d \n",resultado);
		row = mysql_fetch_row (resultado);
		
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta\n");
		else
		{
			while (row !=NULL) 
			{
				// las columnas 0 y 1 contienen DNI y nombre 
				printf ("%s ha jugado un total de %s minutos\n", username,row[0]);
				// obtenemos la siguiente fila
				row = mysql_fetch_row (resultado);
			}
			page_id = atoi(row[0]);
			printf("paso4");
			mysql_close (conn);
			printf("paso5");
		}
	return page_id;
}
/*
/*
int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;paso3

	char buff[512];
	char buff2[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error building socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9008);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Bind Error");
	//La cola de peticiones pendiepaso3
ntes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Listening Error");
	int i;
	
	for(;;){
		printf ("Listening...\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("User connected\n");
		//sock_conn es el socket que usaremos para este cliente
		
		
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
			printf ("paso1\n");
			if(codigo==0){
				kill=1;//Acabar bucle
			}
			printf ("paso2\n");
			
			if(codigo!=0){//Extracción de inf0o0
				printf ("paso2.1\n");
				p = strtok( NULL, "/");
				strcpy(username,p);
				p = strtok( NULL, "/");
				strcpy(password,p);
				//printf ("Packet received: %s\n",username);
				//printf ("Packet received: %s\n",password);
				printf ("Username: %s, Password: %s\n", username, password);
				printf ("paso2.2\n");
				printf("el codigo es: %d\n", codigo);
			}
			if (codigo == 1)//Registrarse a la BBDD
			{
				Register(username,password);//Función de registro a la BBDD
				strcpy(buff2,"Done");
			}		
			
			else if (codigo == 2)//Siguiente servicio
			{
				Loguearse(username,password);
				strcpy(buff2,"Done");
			}							
			else if (codigo == 3)//Siguiente servicio
			{
				printf ("paso3\n");
				int buff1 = ConsultaDavid(username);
				printf("el valor es: %d \n", buff1);
				sprintf(buff2,"%d se ha logueado,", buff1);
			}
			if(codigo!=0)
			{
				printf ("%s\n", buff2);
				// Y lo enviamos
				write (sock_conn,buff2, strlen(buff2));
			}
			// Se acabo el servicio para este cliente
			
		}
		close(sock_conn); //Cerrar conexión
	}
}
*/
int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error building socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9087);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Bind Error");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Listening Error");
	int i;
	
	for(;;){
		printf ("Listening...\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("User connected\n");
		//sock_conn es el socket que usaremos para este cliente
		
		
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
			
			if(codigo!=0){//Extracción de info
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
			
			else if (codigo ==2){//Siguiente servicio
				
				Login(username,password);//Función de Login
				strcpy(buff2,"Done");
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
				ratio=Ratio(username,password);
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
			
			if(codigo!=0){
				printf ("%s\n", buff2);
				// Y lo enviamos
				write (sock_conn,buff2, strlen(buff2));
			}
			// Se acabo el servicio para este cliente
			
		}
		close(sock_conn); //Cerrar conexión
	}
}
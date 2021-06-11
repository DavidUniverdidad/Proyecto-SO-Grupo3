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

typedef struct{//Object 
	
	char username[20];
	int socket;
	int id_player;
	int puntos;
	
	
}TPlayers;

typedef struct{//Lista de ususarios conectados
	
	TPlayers conected[100];
	int num;
	
}TListConnected;



TListConnected list;

typedef struct{
	int id;
	int oc;
	TPlayers usuarios_partida[4];
	
}TPartida;

typedef TPartida TTabla[100];
TTabla tabla_partidas;

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i=0;
int partida=0;
int jugador=0;
//int sockets[100];
int numForm;
int turno;//Variable global de turno de tirada

int ActualizarDatos(char username[20],char usuario_ganador[20]){//Actualiza partidas ganadas/perdidas de cada jugador en la BBDD
	
	printf("\n");
	printf("Entrada funcion. Username: %s, Usuario_Ganador: %s\n",username,usuario_ganador);
	
	if(strcmp(username,usuario_ganador)==0){
		printf("Usuario es el ganador, entrada en if\n");
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
		conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
		if (conn==NULL) {
			printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		printf("Llega a consulta1\n");
		sprintf (consulta,"SELECT WIN_GAMES,TOTAL_GAMES FROM PLAYER WHERE USERNAME='%s'",username);//Generamos la sentencia de consulta
		printf("Hace consulta1\n");
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta
		
		if (err!=0) {
			printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		if (row == NULL){
			
			printf ("User not found\n");
		}
		
		
		int partidas_ganadas=atoi(row[0]);
		int partidas_totales=atoi(row[1]);
		
		printf("Partidas ganadas: %d; Partidas totales: %d\n", partidas_ganadas,partidas_totales);
		
		partidas_ganadas++;//Incremento de cada valor
		partidas_totales++;
		
		printf("[Actualizacion] Partidas ganadas: %d; Partidas totales: %d\n", partidas_ganadas,partidas_totales);
			
		sprintf (consulta,"UPDATE PLAYER SET WIN_GAMES=%d,TOTAL_GAMES=%d WHERE USERNAME='%s'",partidas_ganadas,partidas_totales,username);//Generamos la sentencia de consulta
		printf("Hecha consulta2\n");
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta
		
		return 1;//Todo OK
	}
	
	if(strcmp(usuario_ganador,"None")==0){
		printf("Se ha abandonado la partida antes\n");
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
		conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
		if (conn==NULL) {
			printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		printf("Llega a consulta1\n");
		sprintf (consulta,"SELECT TOTAL_GAMES FROM PLAYER WHERE USERNAME='%s'",username);//Generamos la sentencia de consulta
		printf("Hace consulta1\n");
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta
		
		if (err!=0) {
			printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		if (row == NULL){
			
			printf ("User not found\n");
		}
		
		
		int partidas_ganadas=atoi(row[0]);
		int partidas_totales=atoi(row[1]);
		
		printf("Partidas ganadas: %d; Partidas totales: %d\n", partidas_ganadas,partidas_totales);
		

		partidas_totales++;
		
		printf("[Actualizacion] Partidas totales: %d\n",partidas_totales);
		
		sprintf (consulta,"UPDATE PLAYER SET TOTAL_GAMES=%d WHERE USERNAME='%s'",partidas_totales,username);//Generamos la sentencia de consulta
		printf("Hecha consulta2\n");
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta
		
		return 1;//Todo OK
	}
	
	else{
		
		printf("Usuario es el perdedor, entrada en if\n");
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
		conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
		if (conn==NULL) {
			printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		printf("Llega a consulta1\n");
		sprintf (consulta,"SELECT LOST_GAMES,TOTAL_GAMES FROM PLAYER WHERE USERNAME='%s'",username);//Generamos la sentencia de consulta
		printf("Hace consulta1\n");
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta
		
		if (err!=0) {
			printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		if (row == NULL){
			
			printf ("User not found\n");
		}
		
		
		int partidas_perdidas=atoi(row[0]);
		int partidas_totales=atoi(row[1]);
		
		printf("Partidas perdidas: %d; Partidas totales: %d\n", partidas_perdidas,partidas_totales);
		
		partidas_perdidas++;//Incremento de cada valor
		partidas_totales++;
		
		printf("[Actualizacion] Partidas perdidas: %d; Partidas totales: %d\n", partidas_perdidas,partidas_totales);
		
		sprintf (consulta,"UPDATE PLAYER SET LOST_GAMES=%d,TOTAL_GAMES=%d WHERE USERNAME='%s'",partidas_perdidas,partidas_totales,username);//Generamos la sentencia de consulta
		printf("Hecha consulta2\n");
		// hacemos la consulta 
		err=mysql_query (conn, consulta);//Se realiza la consulta
		
		return 1;//Todo OK
	}
	
}

int AddQuestion(int codigo_num,char enunciado[200],char resp1[200],char resp2[200],char resp3[200],char resp4[200]){
	
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	printf("Primera consulta\n");
	sprintf (consulta,"SELECT MAX(ID_PREGUNTA) FROM PREGUNTAS WHERE ID_CATEGORIA=%d",codigo_num);//Obtenemos id de la ultima pregunta dentro del codigo
	err=mysql_query (conn, consulta);//Se realiza la consulta
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		
		printf ("User not found\n");
	}
	
	
	
	int id_ultima_pregunta=atoi(row[0]);
	
	printf("Ultima id pregunta categoria: %d\n",id_ultima_pregunta);
	id_ultima_pregunta++;
	
	sprintf (consulta,"SELECT MAX(ID) FROM PREGUNTAS");//Obtenemos id de la ultima pregunta 
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
	
	int id_ultima=atoi(row[0]);
	printf("Ultima id pregunta: %d\n",id_ultima);
	id_ultima++;
	
	sprintf(consulta,"INSERT INTO PREGUNTAS VALUES(%d,'%s','%d','%d','%s','%s','%s','%s')",id_ultima,enunciado,id_ultima_pregunta,codigo_num,resp1,resp2,resp3,resp4);
	printf("Consulta: %s\n",consulta);

	err=mysql_query (conn, consulta);//Se realiza la consulta (insertar usuarios al sistema)
	
	return id_ultima_pregunta;//devuelve numero de preguntas
}
int GetNumQuestions(){//Obtener id maximo BBDD preguntas
	
	printf("Dentro la funcion GetNumQuestions\n");
	
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	printf("Primera consulta\n");
	
	sprintf (consulta,"SELECT MAX(ID_PREGUNTA) FROM PREGUNTAS WHERE ID_CATEGORIA");//Obtenemos maximo id de las categorias
	err=mysql_query (conn, consulta);//Se realiza la consulta
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL){
		
		printf ("User not found\n");
	}
	
	
	
	int id_max=atoi(row[0]);
	
	printf("Ultima id pregunta categoria: %d\n",id_max);
	
	return id_max;
}
int AddUsersGame(TTabla *tabla_partidas,char usernames[100]){//AÒadir usuarios a la tabla
	printf("Entrada a AÒadir Usuarios Juego\n");
	int i=0;
	int encontrado=0;
	char user[20];
	int num_partida;
	
	printf("var Partida: %d\n",partida);
	
	int k=0;
	while(k<4){//Limpiar tabla
		
		strcpy(tabla_partidas[i]->usuarios_partida[k].username,"");
		tabla_partidas[i]->usuarios_partida[k].socket=0;//Limpiar socket tambiÈn
		
		k++;
	}
	k=0;
	
		
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
			tabla_partidas[partida]->usuarios_partida[jugador].id_player=jugador;
			tabla_partidas[partida]->usuarios_partida[jugador].puntos=0;
			
			printf("(Jugador %d) Usuario: %s, Socket: %d, ID Partida: %d\n",tabla_partidas[partida]->usuarios_partida[jugador].id_player,tabla_partidas[partida]->usuarios_partida[jugador].username,tabla_partidas[partida]->usuarios_partida[jugador].socket,tabla_partidas[partida]->id);
			
			jugador++;
			
			while(p!=NULL){
				
			p = strtok(NULL,"/");
			
			if(p!=NULL){
				strcpy(user,p);//Obtener username
				socket=GetUserSocket(&list,user);//Obtener socket
				
				strcpy(tabla_partidas[partida]->usuarios_partida[jugador].username,user);
				tabla_partidas[partida]->usuarios_partida[jugador].socket=socket;
				tabla_partidas[partida]->usuarios_partida[jugador].puntos=0;
				printf("(Jugador %d) Usuario: %s, Socket: %d, ID Partida: %d\n",jugador,tabla_partidas[partida]->usuarios_partida[jugador].username,tabla_partidas[partida]->usuarios_partida[jugador].socket,tabla_partidas[partida]->id);
				
				jugador++;
				}
			}
			printf("\n");
			return partida;//Ha aÒadido usuario con Èxito
	
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
	
	int j=0;
	printf("Usuario a Eliminar: %s; Partida escogida %d; Valor i: %d\n",username,i,num_partida);
	printf("Entrada en bucle\n");

		while((j<4)&&(encontrado==0)){

			if(strcmp(tabla_partidas[i].usuarios_partida[j].username,username)==0){//Buscar en esa partida el nombre
				encontrado=1;
				printf("Usuario a eliminar encontrado\n");
			}
			else{
				j++;
			}
		}
		
		if(encontrado==1){
			int k=j;
			
			while(k<4){
				
				strcpy(tabla_partidas[i].usuarios_partida[k].username,tabla_partidas[i].usuarios_partida[k+1].username);//Eliminar usuario de tabla
				tabla_partidas[i].usuarios_partida[k].socket=tabla_partidas[i].usuarios_partida[k+1].socket;//Eliminar socket tambiÈn
				
				k++;
			}
		}
		printf("Salida funciÛn eliminar\n");
	
	return 0;
	
}

void GetConnectedUsers(TListConnected *list,char online_users[100]){//Obtener usuarios conectados
	
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

int AddUser(TListConnected *list, char name[20],int socket_num){//A√±adir usuario a la lista
	if(list->num==100){
		return -1;//Lista llena
	}
	
	else{
		strcpy(list->conected[list->num].username,name);//A√±adir el nombre del usuario a la lista
		list->conected[list->num].socket=socket_num;
		printf("%s,%d ; numero socket: %d\n",list->conected[list->num].username,list->num,list->conected[list->num].socket);
		list->num++;//Incremento de la lista 1 ud
		
		return 0;
	}
}

void AddPoints(TTabla *tabla_partidas,char usuario[100],int puntos,char resultado_puntos[200]){//AÒadir puntos a usuarios
	
	printf("Entrada a AÒadir Puntos Juego\n");
	int j=0;
	int encontrado=0;

	while((j<4)&&(encontrado==0)){//AÒadir puntos al usuario
		printf("Entrada a bucle1\n");
		if(strcmp(tabla_partidas[0]->usuarios_partida[j].username,usuario)==0){
			encontrado=1;
			printf("Nombre: %s Posicion: %d\n",tabla_partidas[0]->usuarios_partida[j].username,j);
		}
		else{
			j++;
		}
	}
	if(encontrado==1){
		tabla_partidas[0]->usuarios_partida[j].puntos=puntos;
		printf("Puntos de %s: %d\n",tabla_partidas[0]->usuarios_partida[j].username,tabla_partidas[0]->usuarios_partida[j].puntos);
	}//Guardar puntos a la posicion del usuario
	else{
		printf("ERROR, Usuario no encontrado\n");
	}
	
		sprintf(resultado_puntos,"%d",j);
		printf("Segundo bucle, entrada\n");
		sprintf(resultado_puntos,"%s/%d",resultado_puntos,puntos);
		printf("%s\n",resultado_puntos);
	
	printf("variable resultado_puntos: %s\n",resultado_puntos);
	
}

int GetUserSocket(TListConnected *list, char username[20]){//Obtener Socket dado un username
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
		list->conected[i].socket=list->conected[i+1].socket;
		printf("Eliminado: %s,Num Usuarios: %d\n",name,list->num);
		list->num=list->num-1;
		return 0;
	}
	else{
		return -1;//error
	}
}



void Register (char username[20], char password[20])//Registrar un usuario en BBDD
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
		printf ("No data from request\n");//No hay fila, por tanto la tabla est√° vac√≠a (no hay resultado)
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
		
		err=mysql_query (conn, "SELECT * FROM PLAYER");//Consulta para ver lo que se ha aÒadido
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
int Login(char username[20], TListConnected *list,char password[20]){//Logear usuario 
	
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
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
float GetRatio(char username[20], char password[20])//Obtener Consulta1 (Ratio partidas ganadas)
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
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
	res = roundf(res * 100);
	printf("Result: %f\n",res);
	return res;
}
int GetDuration(char username[20],char password[20])//Obtener Consulta2 (Partidas perdidas)
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
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT LOST_GAMES FROM PLAYER WHERE USERNAME='%s'; ",username);//Generamos la sentencia de consulta
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
	int perdidas=atoi(row[0]);
	printf("Partidas perdidas: %d\n", perdidas);
	mysql_close(conn);
	
	return perdidas;
}

int ConsultaSergi(char username[20], char password[20])//Obtener Consulta3 (Partidas ganadas)
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [100];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error al crear la conexi√≥n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
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

int Consulta_Pregunta(int codigo_pregunta, int id_pregunta,char pregunta_respuestas[600])//Obtener preguntas-respuestas para el juego de la BBDD
{
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [2000];
	
	conn = mysql_init(NULL);//Crear consulta
	if (conn==NULL) {
		printf ("Error al crear la conexi√≥n: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T3_trivial",0, NULL, 0);//Iniciar conexi√≥n con BBDD
	if (conn==NULL) {
		printf ("Error while trying to initialize database: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	sprintf (consulta,"SELECT ENUNCIADO,RESPUESTA1,RESPUESTA2,RESPUESTA3,RESPUESTA4 FROM PREGUNTAS WHERE ID_CATEGORIA=%d AND ID_PREGUNTA=%d",codigo_pregunta,id_pregunta);//Generamos la sentencia de consulta
	// hacemos la consulta 
	err=mysql_query (conn, consulta);//Se realiza la consulta
	
	if (err!=0) {
		printf ("Error al realizar la consulta en la bbdd %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	printf("Enunciado: %s, R1: %s \n",row[0],row[1]);
	
	if (row == NULL){
		
		printf ("No hay ninguna pregunta con este identificador/codigo\n");
		mysql_close(conn);
		return -1;
	}
	else{
		sprintf(pregunta_respuestas,"%s/%s/%s/%s/%s",row[0],row[1],row[2],row[3],row[4]);
		mysql_close(conn);
		return 0;
	}
	
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
		
		
		buff[ret]='\0';//Se a√±ade marca de fin de l√≠ne de la string
		
		printf ("Packet received: %s\n",buff);
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);//Extracci√≥n de c√≥digo del servicio
		
		if(codigo==0){//Desconexion usuario, se envia notificacion [6/usuarios_conectados]
			
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
							write (list.conected[j].socket,notificacion, strlen(notificacion));
							j++;
						}
					}
				
			}
			else{
				printf("Couldn't deleted from list\n");
			}
			kill=1;//Acabar bucle(Usuario desconectado)
		}
		
		if((codigo!=0)&&(codigo!=7)&&(codigo!=8)&&(codigo!=9)&&(codigo!=10)&&(codigo!=11)&&(codigo!=12)&&(codigo!=13)&&(codigo!=14)&&(codigo!=15)&&(codigo!=16)&&(codigo!=17)){//Extracci√≥n de info
			p = strtok( NULL, "/");  
			strcpy(username,p);
			p = strtok( NULL, "/");
			strcpy(password,p);
			
			printf ("Username: %s, Password: %s\n",username,password);
			
		}
		
		if(codigo==7){//Se genera la string necesaria para enviar todos los nombres de jugadores a la funcion AddUsersGame
			printf("Entrada pre-servicio 7\n");
			p = strtok( NULL, "/");
			int numForm=atoi(p);
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
		
		if (codigo ==1){//Registrarse a la BBDD [1/Done]
			Register(username,password);//Funci√≥n de registro a la BBDD
			strcpy(buff2,"1/Done");
		}		
		
		if (codigo ==2){//Login [2/Done] o [2/Fail]
			int res;
			
			pthread_mutex_lock(&mutex);//No interrumpir
			res=Login(username,&list,password);
			pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
			
			if(res==0){//Existe usuario en el sistema
				
				pthread_mutex_lock(&mutex);//No interrumpir
				int user_added = AddUser(&list,username,sock_conn);//AÒadir usuario lista conectados
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
		if (codigo == 3)//Peticion obtener partidas perdidas [3/partidas_perdidas]
		{
			printf ("paso3\n");
			int res1;
			res1 = GetDuration(username,password);
			printf("el valor es: %d \n", res1);
			sprintf(buff2,"3/%d", res1);
		}
		if (codigo ==4)//Peticion obtener ratio [4/ratio] o [4/Fail]
		{
			
			float ratio;
			ratio=GetRatio(username,password);
			if(ratio > 0){
				sprintf(buff2,"4/%f",ratio);
				//strcpy(buff2,"Done,");
			}
			else
			   strcpy(buff2,"4/Fail");
			
		}
		
		if (codigo ==5)//Peticion obtener partidas ganadas [5/partidas_ganadas]
		{
			
			int res2 = ConsultaSergi(username,password);
			sprintf(buff2,"5/%d",res2);
		}
		
		if (codigo ==7)//Invitacion a partida [7/usuario_quien_invita/num_partida]
		{
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
			num_partida=AddUsersGame(&tabla_partidas,users);//AÒadir todos los usuarios
			pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
			
			jugador=0;//Resetear var global conteo jugadores/partida
			//partida++;//Revisar
			printf("Incremento partida, nuevo valor: %d\n",partida);
			
			if(num_partida!=-1){
				printf("Usuarios aÒadidos a la partida\n");
			}
			else{
				printf("Usuarios NO aÒadidos a partida\n");
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
			printf("Mensaje enviado: %s\n",mensaje);
			
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
		
		if (codigo ==8)//Aceptar peticiÛn [8/usuario_quien_acepta/1] o  [8/usuario_quien_rechaza/0]
		{
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
			
			if(strcmp(respuesta,"SI")==0){//Se Acepta la partida
				
				sprintf(buff2,"8/%s/1",username_origin);
				printf("%s envia respuesta de la peticion a %s; Formato: %s\n",username_origin,username_dest,buff2);
				write (socket_dest,buff2, strlen(buff2));//Enviar mensaje al socket destinatario
				printf("Enviado\n");
				
			}
			if(strcmp(respuesta,"NO")==0){//Se rechaza la partida
				
				pthread_mutex_lock(&mutex);//No interrumpir
				int res=DeleteUsersGame(username_origin,0);
				pthread_mutex_unlock(&mutex);//Ya puedes interrumpir
				if(res==0){
					
					sprintf(buff2,"8/%s/0",username_origin);
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
			
		//AÒadir en tabla de partida este usuario y tx + sus sockets
			
		}
		
		if (codigo ==9)//Notificar a los jugadores invitados que ya pueden empezar la partida [9/usuario_quien_invita]
		{
			
			printf("Entrada serv 9\n");
				char username[20];
				p = strtok(NULL, "/"); 
				strcpy(username,p);
				char notificacion2[100];
				sprintf(notificacion2,"9/%s",username);
				int socket_dest;
				
				printf("\n");
				printf("username: %s\n",username);
				printf("username tabla pos 0: %s\n",tabla_partidas[0].usuarios_partida[0].username);
				printf("num jugador tabla pos 0: %s\n",tabla_partidas[0].usuarios_partida[0].id_player);
				printf("socket tabla pos 0: %d\n",tabla_partidas[0].usuarios_partida[0].socket);
				printf("username tabla pos 1: %s\n",tabla_partidas[0].usuarios_partida[1].username);
				printf("num jugador tabla pos 1: %s\n",tabla_partidas[0].usuarios_partida[1].id_player);
				printf("socket tabla pos 1: %d\n",tabla_partidas[0].usuarios_partida[1].socket);
				printf("\n");
				
				int j=0;
				while(j<4){//Solo para primera y unica partida en tabla
					
					if(strcmp(tabla_partidas[0].usuarios_partida[j].username,username)!=0){//No enviar mensaje al propio emisor
						socket_dest=tabla_partidas[0].usuarios_partida[j].socket;
						printf("socket destino: %d, se envia mensaje: %s\n",socket_dest,notificacion2);
						
						write (socket_dest,notificacion2, strlen(notificacion2));
					}

					j++;
				}
		}
		
		if (codigo ==10)//Notificacion de movimiento de ficha [10/usuario_que_ha_tirado/numero_dado/id_siguiente_usuario/nombre_siguiente_ususario]
		{
			printf("Movimento ficha (Entrada serv 10)\n");
			char username[20];
			p = strtok(NULL, "/"); 
			strcpy(username,p);
			p = strtok(NULL, "/");
			int num=atoi(p);
			
			char notificacion3[100];
			int socket_dest;
			char usuario_turno[20];
			
			int j=0;
			int encontrado=0;
			while((j<4)&&(encontrado==0)){//Solo para primera y unica partida en tabla
				
				if(strcmp(tabla_partidas[0].usuarios_partida[j].username,username)==0){//encontrar posicion emisor (identificador)
					encontrado=1;
				}
				else{
					j++;
				}
			}
			
			turno=j+1;//Turno para el siguiente jugador de la tabla
			strcpy(usuario_turno,tabla_partidas[0].usuarios_partida[j+1].username);//Nombre siguiente usuario turno
				
			if(tabla_partidas[0].usuarios_partida[j+1].socket==0){//No hay jugador en la siguiente posicion
				turno=0;//reset de turno
				strcpy(usuario_turno,tabla_partidas[0].usuarios_partida[0].username);
			}
			
			int cont=0;
			while(cont<4){
				
				socket_dest=tabla_partidas[0].usuarios_partida[cont].socket;//Se envia a todos, incluido emisor
				sprintf(notificacion3,"10/%s/%d/%d/%d/%s",username,num,j,turno,usuario_turno);
				
				printf("socket destino: %d, se envia notificacion3: %s\n",socket_dest,notificacion3);
				
				write (socket_dest,notificacion3, strlen(notificacion3));
				
			cont++;
			}
		}
		if (codigo ==11)//Notificacion dar datos para inicio de partida [ 11/longitud_mensaje/Jug1/id_jug1/Jug2/Id_Jug2/.../total_jugadores ]
		{
			char username[20];
			p = strtok(NULL, "/"); 
			strcpy(username,p);
			char notificacion3[800];
			int j=0;
			int longitud=0;
			int cont=0;
			
			int id_max=GetNumQuestions();
			
			printf("Num max preguntas: %d \n",id_max);
			
			//int socket_dest;
			while(j<4){//Encontrar total jugadores activos
				
				if(tabla_partidas[0].usuarios_partida[j].socket!=0){
					cont++;
				}
				j++;
			}
			
			
			j=1;
			
			char usuarios_juego[200];
			sprintf(usuarios_juego,"%s/%d/",tabla_partidas[0].usuarios_partida[0].username,0);
			printf("Inicial: %s\n",usuarios_juego);
			longitud=2;
			
			while(j<4){
				if(tabla_partidas[0].usuarios_partida[j].socket!=0){
					
					sprintf(usuarios_juego,"%s%s/%d/",usuarios_juego,tabla_partidas[0].usuarios_partida[j].username,j);
					printf("AÒadiendo: %s [Longitud mensaje: %d]\n",usuarios_juego,longitud);
					longitud=longitud+2;
				}
					j++;
				
			}
			printf("Resultado variable final: %s [Longitud mensaje: %d]\n",usuarios_juego,longitud);
			
				//if(strcmp(tabla_partidas[0].usuarios_partida[j].username,username)==0){
					longitud++;
					sprintf(notificacion3,"11/%d/%s%d/%d",longitud,usuarios_juego,cont,id_max);
					printf("socket destino: %d, se envia mensaje: %s\n",sock_conn,notificacion3);
					
					write (sock_conn,notificacion3, strlen(notificacion3));
				//}
				

		}
		
		if (codigo == 12){ //Notificacion chat [12/usuario_origen/texto]
			char username[20];
			char text[240];
			p = strtok(NULL, "/"); 
			strcpy(username,p);
			p = strtok(NULL, "/");
			strcpy(text,p);
			
			char notificacion4[100];
			
			int j=0;
			int cont=0;
			
			while (j<4)
			{
					sprintf(notificacion4, "12/%s/%s", username, text);
					printf("socket destino: %d, se envia mensaje: %s\n",list.conected[j].socket,notificacion4);
					
					write (tabla_partidas[0].usuarios_partida[j].socket,notificacion4, strlen(notificacion4));
				j++;
			}
			
		}
		
		if (codigo == 13){ //NotificaciÛn para enviar juego pregunta-respuesta a la bbdd [13/codigo_color_casilla/id_pregunta]
			
			p=strtok(NULL,"/");
			char username[20];
			strcpy(username,p);
			p=strtok(NULL,"/");
			int codigo_pregunta=atoi(p);
			p=strtok(NULL,"/");
			int id_pregunta=atoi(p);
			char pregunta_respuestas[800];
			
			printf("Entrada a funcion\n");
			printf("id_pregunta: %d, id_codigo: %d\n",id_pregunta,codigo_pregunta);
			int err=Consulta_Pregunta(codigo_pregunta,id_pregunta,pregunta_respuestas);
			
			if (err==-1){
				printf("Error, consulta no posible!\n");
			}
			printf("Pregunta-Respuestas: %s\n",pregunta_respuestas);
			
			int pos=0;
			int j=0;
			
			int encontrado=0;
			while((pos<4)&&(encontrado==0)){
				
				if(strcmp(tabla_partidas[0].usuarios_partida[pos].username,username)==0){//encontrar posicion emisor (identificador)
					encontrado=1;
				}
				else{
					pos++;
				}
			}
			char notificacion5[800];
			sprintf(notificacion5,"13/%s/%d/",pregunta_respuestas,pos);
			
			while (j<4)
			{
				printf("socket destino: %d, se envia mensaje: %s\n",tabla_partidas[0].usuarios_partida[j].socket,notificacion5);
				
				write (tabla_partidas[0].usuarios_partida[j].socket,notificacion5, strlen(notificacion5));
				j++;
			}
			
		}
		
		if (codigo ==14)//Enviar notificacion actualizacion de puntos [14/identificador/puntos]
		{
			p=strtok(NULL,"/");
			char username[100];
			strcpy(username,p);
			p=strtok(NULL,"/");
			int puntos;
			puntos=atoi(p);
			printf("Puntos a aÒadir: %d\n",puntos);
			
			char notificacion6[200];
			char resultado_puntos[200];
			
			AddPoints(&tabla_partidas,username,puntos,resultado_puntos);
			sprintf(notificacion6,"14/%s",resultado_puntos);
			
			int j=0;
			while (j<4)
			{
				printf("socket destino: %d, se envia mensaje: %s\n",tabla_partidas[0].usuarios_partida[j].socket,notificacion6);
				
				write (tabla_partidas[0].usuarios_partida[j].socket,notificacion6, strlen(notificacion6));
				j++;
			}
		}
		
		if (codigo ==15)//Notificacion para enviar ganador 15/usuario_ganador]
		{
			p=strtok(NULL,"/");
			char username[20];
			strcpy(username,p);
			
			
			char notificacion7[200];
			sprintf(notificacion7,"15/%s",username);
			
			int j=0;
			while (j<4)
			{
				printf("socket destino: %d, se envia mensaje: %s\n",tabla_partidas[0].usuarios_partida[j].socket,notificacion7);
				
				write (tabla_partidas[0].usuarios_partida[j].socket,notificacion7, strlen(notificacion7));
				j++;
			}
		}
		
		if (codigo ==16)//Actualiza datos de cada jugador en BBDD al finalizar partida [NO hay respuesta]
		{
			p=strtok(NULL,"/");
			char username[20];//NOmbre local
			strcpy(username,p);
			p=strtok(NULL,"/");
			char usuario_ganador[20];//Nombre ganador
			strcpy(usuario_ganador,p);
			
			int res=ActualizarDatos(username,usuario_ganador);
			if(res==1){
				printf("Info Actualizada correctamente\n");
				
			}
			
			else{
				printf("Error\n");
			}
		}
		
		if(codigo==17){//Enviar cambios en BBDD [17/numero_pregunta_ultima_categoria/id_categoria]
			
			printf("Entrada a la funcion 17\n");
			
			p=strtok(NULL,"/");
			int num_categoria=atoi(p);//valor categoria
			printf("Codigo: %d\n",num_categoria);
			
			p=strtok(NULL,"/");
			char enunciado[500];//Enunciado pregunta
			strcpy(enunciado,p);
			printf("Enunciado: %s\n",enunciado);
			
			p=strtok(NULL,"/");
			char resp1[500];//R1
			strcpy(resp1,p);
			printf("Resp1: %s\n",resp1);
			
			p=strtok(NULL,"/");
			char resp2[500];//R2
			strcpy(resp2,p);
			printf("Resp2: %s\n",resp2);
			
			p=strtok(NULL,"/");
			char resp3[500];//R3
			strcpy(resp3,p);
			printf("Resp3: %s\n",resp3);
			
			p=strtok(NULL,"/");
			char resp4[500];//R4
			strcpy(resp4,p);
			printf("Resp4: %s\n",resp4);
			
			printf("ANtes entrar a la funcion\n");
			int res=AddQuestion(num_categoria,enunciado,resp1,resp2,resp3,resp4);
			printf("Despues de entrar a la funcion\n");
			
			char mensaje[200];
			sprintf(mensaje,"17/%d/%d",res,num_categoria);
			printf("Mensaje a enviar: %s\n",mensaje);
			write (sock_conn,mensaje, strlen(mensaje));
		}

		if((codigo!=0)&&(codigo!=7)&&(codigo!=8)&&(codigo!=9)&&(codigo!=10)&&(codigo!=11)&&(codigo!=12)&&(codigo!=13)&&(codigo!=14)&&(codigo!=15)&&(codigo!=16)&&(codigo!=17)){
			printf ("%s\n", buff2);
			// Y lo enviamos
			write (sock_conn,buff2, strlen(buff2));
		}
		// Se acabo el servicio para este cliente
		if ((codigo ==1)|(codigo ==2)|(codigo ==3)|(codigo ==4)|(codigo ==5))//Cada vez que se hagan una de estas peticiones, se actualizar· el num. conectados
		{//Cada vez que se hagan una de estas peticiones, se actualizar· el num. conectados
			
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
				printf("Notificacion enviada: %s\n",notificacion);
				
				int j=0;
				while(j<i){
					write (list.conected[j].socket,notificacion, strlen(notificacion));
					j++;
				}
			}
		}
		
		
	}
	close(sock_conn); //Cerrar conexi√≥n
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
	serv_adr.sin_port = htons(50076);
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
		
		list.conected[i].socket = sock_conn;
		
		//sock_conn es el socket que usaremos para este cliente
		
		//crear thead y decirle lo que tiene que hacer
		printf("Entrada\n");
		pthread_create (&thread[i], NULL, AtenderCliente,&list.conected[i].socket);
		i++;
	}
}

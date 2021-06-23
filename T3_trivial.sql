DROP DATABASE IF EXISTS T3_trivial;
CREATE DATABASE T3_trivial;

USE T3_trivial;

CREATE TABLE PLAYER(
	
	ID INT NOT NULL,
	USERNAME VARCHAR(20) NOT NULL,
	PASSWORD VARCHAR(20) NOT NULL,
	WIN_GAMES INT,
	LOST_GAMES INT,
	TOTAL_GAMES INT,
	PRIMARY KEY(ID)

)ENGINE=InnoDB;

CREATE TABLE PREGUNTAS(
	
	ID INT NOT NULL,
	ENUNCIADO VARCHAR(80) NOT NULL,
	ID_PREGUNTA INT NOT NULL,
	ID_CATEGORIA INT NOT NULL,
	RESPUESTA1 VARCHAR(80) NOT NULL,
	RESPUESTA2 VARCHAR(80) NOT NULL,
	RESPUESTA3 VARCHAR(80) NOT NULL,
	RESPUESTA4 VARCHAR(80) NOT NULL,
	PRIMARY KEY(ID)

)ENGINE=InnoDB;

INSERT INTO PREGUNTAS VALUES(1,'Quien invento el generador de AC?',1,1,'Nikola Tesla','Pitagoras','Rajoy','Messi');
INSERT INTO PREGUNTAS VALUES(2,'Quien invento el generador de DC?',2,1,'Thomas Edison','James Bond','Newton','Risitas');
INSERT INTO PREGUNTAS VALUES(3,'Cual es un elemento activo?',3,1,'Bobina','Resistencia','Fusible','Transformador');
INSERT INTO PREGUNTAS VALUES(4,'Cual es un regulador commutado?',4,1,'Buck','Thevenin','TL084','LM315');
INSERT INTO PREGUNTAS VALUES(5,'Cual es un elemento disipativo?',5,1,'Resistencia','Bobina','Condensador','Diodo');


INSERT INTO PREGUNTAS VALUES(6,'Cuanto vale pi?',1,2,'3.14','2.7','3.167','2.34');
INSERT INTO PREGUNTAS VALUES(7,'Cuanto vale e?',2,2,'2.7','3.14','1.86','2.34');
INSERT INTO PREGUNTAS VALUES(8,'El resultado de dividir un numero entre infinito es...',3,2,'0','Infinito','Numero','Exponencial');
INSERT INTO PREGUNTAS VALUES(9,'Con que herramienta se analiza una respuesta transitoria?',4,2,'TL','TF','MTTP','FTT');
INSERT INTO PREGUNTAS VALUES(10,'Con que herramienta se analiza una funcion de transferencia?',5,2,'TL','FTT','MTTP','TF');


INSERT INTO PREGUNTAS VALUES(11,'Cual de estos es imprescidibles en la programacion?',1,3,'IF','ROUND','ADD','SELECT');
INSERT INTO PREGUNTAS VALUES(12,'Que se utiliza para escribir en un FORMS?',2,3,'TextBox','Label','MessageBox','ToolBar');
INSERT INTO PREGUNTAS VALUES(13,'Que se utiliza para mostrar un mensaje en FORMS?',3,3,'Label','MessageBox','ToolBox','ToolBar');
INSERT INTO PREGUNTAS VALUES(14,'Quien ha sido profesor de SO en 2021-2?',4,3,'Miguel','Josete','Antonia','Aneglica');
INSERT INTO PREGUNTAS VALUES(15,'Cual de estos es un sistema UNIX?',5,3,'Linux','WIndows','IOS','Android');


INSERT INTO PREGUNTAS VALUES(16,'Cual no forma parte del CBL?',1,4,'FIB','EETAC','ESEIAAT','ICO');
INSERT INTO PREGUNTAS VALUES(17,'Cuantos grados se dan en la EETAC?',2,4,'3','2','5','1');
INSERT INTO PREGUNTAS VALUES(18,'Cuantas personas han suspendido API?',3,4,'300','123','2','50');
INSERT INTO PREGUNTAS VALUES(19,'Cuando se fundo la UPC?',4,4,'1975','1953','1992','2003');
INSERT INTO PREGUNTAS VALUES(20,'Que hay al lado de la EETAC?',5,4,'ETSEIB','UAB','UB','UDL');


INSERT INTO PLAYER VALUES(1,'Juan','juan123',2,3,5);
INSERT INTO PLAYER VALUES(2,'David','david1',5,0,5);
INSERT INTO PLAYER VALUES(3,'Pepe','pepe11',6,2,8);
INSERT INTO PLAYER VALUES(4,'Ferran','ferran3',5,3,8);
INSERT INTO PLAYER VALUES(5,'Esther','estermens',1,1,2);

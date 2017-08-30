#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include "conio.h"
#include "conio.c"
#include <string.h>
#include <iomanip>


//hola mundo
using namespace std;

void adicionar();
void listar();
void eliminar();
void modificar();


typedef struct NODO NODO;
struct NODO{
       NODO *ant;
       int   info;
       NODO *sig;
};
NODO *aux,*auxb,*auxc,*cab,*fin=NULL;




int main(){
    system("color 4a");     
	char seguir = 's';
	while (seguir != '5'){
		clrscr();
		textbackground(BLACK);
		textcolor(WHITE);
		gotoxy(20, 24); cout << "                              ";
		gotoxy(27, 2); cout << " METAPODSOFT 1.0-listass";
		gotoxy(27, 3); cout << "-------------------------";
		gotoxy(30, 6); cout << "1.-Adicion ";
		gotoxy(30, 8); cout << "2.-listar";
		gotoxy(30, 10); cout << "3.-modificar";	
        gotoxy(30, 12); cout << "4.-eliminar";	
        gotoxy(30, 14); cout << "5.-salir";	
		gotoxy(30, 24); cout << "Escoja la Opcion : ";
		gotoxy(49, 24); seguir = getche();
		switch (seguir){
		case '1':{
			adicionar();
			break;
		}
		case '2':{
             //ordenar();
            listar();
			break;
		}
		case '3':{
             //ordenar();
            modificar();
			break;
		}
		case '4':{
             //ordenar();
            eliminar();
			break;
		}
		
		}
		clrscr();
	}

}

void adicionar(){
   clrscr();
  gotoxy(30,4); cout<<"CAPTURA DE DATOS";
  gotoxy(28,6);cout<<"Informacion:[";
  gotoxy(50,6); cout<<"]"; 
  auxb=new struct NODO;  
  gotoxy(41,6); cin>>auxb->info;

  if(cab==NULL){
                cab=auxb;
                cab->sig=NULL;
                cab->ant=NULL;
                fin=cab;
  }else{
        fin->sig=auxb;
        auxb->sig=NULL;
        auxb->ant=fin;
        fin=auxb;      
  }
  
}

void listar(){
     clrscr();
     gotoxy(1,1);
     auxb=cab;
     if(cab==NULL){
                   cout<<"lista Vacia"<<endl;
     }else{
           while(auxb!=NULL){
                             cout<<auxb->info<<endl;
                             auxb=auxb->sig;
           }
     }
     getch();
}

void eliminar(){
     int flag=0;
     int valor;
      clrscr();
     gotoxy(1,1);     
     auxb=cab;     
     aux=NULL;
     cout<<"ingrese el valor a eliminar"<<endl;
     cin>>valor;
     if(cab==NULL){
      cout<<"lista Vacia"<<endl;
     }else{
           while(auxb!=NULL && flag==0){
            if(auxb->info==valor){
                cout<<"valor encontrado"<<endl;  
                if(auxb==cab){
                  cab=cab->sig;
                } else{
                       if(auxb=fin){
                          aux->sig=NULL;
                          fin=aux;         
                        }else{
                          aux->sig=auxb->sig;
                          auxb->sig->ant=aux;
                        }
                        flag=1;
                }          
             }
             aux=auxb;
                   auxb=aux->sig;
                    
           }
     }
}
void modificar(){
     int valor,valor2;
     clrscr();
     gotoxy(1,1);
     auxb=cab;
      cout<<"ingrese el valor a modificar"<<endl;
     cin>>valor;     
     if(cab==NULL){
                   cout<<"lista Vacia"<<endl;
     }else{
           while(auxb!=NULL){
                             if(auxb->info== valor){
                                             cout<<"ingrese el valor a modificar"<<endl;
                                             cin>>valor2;
                                             auxb->info=valor2;
                                             }                             
                             auxb=auxb->sig;
           }
     }
     getch();
}


[![GitHub issues](https://img.shields.io/github/issues/MOON-TYPE/MDoc.svg)](https://github.com/MOON-TYPE/MDoc/issues)
[![UnityVersion](https://img.shields.io/badge/Unity-2017.3.1f1-blue.svg)](https://unity3d.com/es)
[![Trello](https://img.shields.io/badge/Trello-OFF-red.svg)](https://github.com/MOON-TYPE/MDoc)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/MOON-TYPE/MDoc/master/LICENSE)

# MDoc
Herramienta para crear documentacion rapida y simple en Unity3D (mediante codigo)

<p align="center"><img src="https://github.com/MOON-TYPE/MDoc/blob/master/Res/preview/preview.png?raw=true"></p>

## Descripcion

Herramienta para crear documentacion sobre los niveles, codigo, etc.. facil y sin grandes copilaciones.

## Como usar

En MDocEditor.cs

* Añade al enum MenuActual todos los menus que quieras usar.(MenuDev,MenuSistema,MenuClase ...)
* Crea un metodo para la GUI de los menus.
* En #region Funcional > ActualizarMenu() ingresa los nuevo menus.(Dentro del switch) y llama al metodo anterior.

__(En #region Secciones Documentacion puede ver algunos ejemplos de Menus.)__

En el metodo creado

* Inicia el menu usando InicioMenu()
* Escribe lo que necesites con Titulo(),Texto(),Espacio(),Imagen().. de forma ordenada y lineal
* Cierra el menu usando FinMenu()


## API

+ Inicio de un menu
```C#
public void InicioMenu()
```

+ Fin de un menu
```C#
public void FinMenu()
```

+ Crear un boton en la documentacion
```C#
public void Boton(string nomBtn, MenuActual menu)
public void Boton(string nomBtn,MenuActual menu,bool espacio)
public void Boton(string texto, string url)
```

+ Crear un titulo en la documentacion
```C#
public void Titulo(string texto)
public void Titulo(string texto,bool negrita)
```

+ Crear un texto
```C#
public void Texto(string texto)
```

+ Crea un separador standart
```C#
public void Separador()
```

+ Crea un espacio de un tipo fijado
```C#
public void Espacio(TipoEspacio tipo)
```

+ Crea una imagen
```C#
public void Imagen(Texture2D texture,float width,float height)
```

+ Inicia un scroll
```C#
public void InicioScroll()
```

+ Finaliza un scroll
```C#
public void FinScroll()
```


## Licencias & Atribuciones

+ Gracias a [Wlop][1] por el BG de BG.Doc.png


[1]: http://wlop.deviantart.com/

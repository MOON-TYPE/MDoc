# MDoc
Herramienta para crear documentacion rapida y simple en Unity3D

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
FinScroll()
```


## Licencias & Atribuciones

+ Gracias a [Wlop][1] por el BG de BG.Doc.png


[1]: http://wlop.deviantart.com/
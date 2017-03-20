//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MDocEditor.cs (20/03/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Herramienta para crear una documentacion simple.			\\
// Fecha Mod:		20/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Herramienta para crear una documentacion simple</para>
	/// </summary>
	public class MDocEditor : EditorWindow
	{
		#region Ajustes
		public string nombreDoc = "MDoc";
		public string versionDoc = "1.0.0";
		#endregion

		#region Variables Privadas
		private GUISkin estilo;

		private GUIStyle wordWrapped;
		private GUIStyle headerText;
		private GUIStyle seccionHeader;
		private GUIStyle tituloNegrita;
		private GUIStyle numVersion;
		private GUIStyle tituloWindow;
		private GUIStyle btnBack;

		private int smallSpace = 8;
		private int mediumSpace = 12;
		private int largeSpace = 20;

		GUILayoutOption[] btnSize = new GUILayoutOption[] { GUILayout.Width(200), GUILayout.Height(35) };
		GUILayoutOption[] docSize = new GUILayoutOption[] { GUILayout.Width(300), GUILayout.Height(330) };

		private static MenuActual menuActual;
		private static string tituloMenu = "Menu Principal";
		#endregion

		#region Menu
		/// <summary>
		/// <para>Inicia MDoc.</para>
		/// </summary>
		[MenuItem("Moon Antonio/MDoc", false, 0)]
		public static void InitMDoc()// Inicia MDoc
		{
			Texture icono = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Moon Antonio/MDoc/Icon/mdoc.icon.png");
			GUIContent tituloContenido = new GUIContent(" MDoc", icono);

			EditorWindow window = GetWindow<MDocEditor>(true,tituloContenido.text,true);
			window.titleContent = tituloContenido;
			window.maxSize = new Vector2(500, 500);
			window.minSize = new Vector2(500, 500);
			window.Show();
		}
		#endregion

		#region Iniciadores
		/// <summary>
		/// <para>Cuando esta activo.</para>
		/// </summary>
		private void OnEnable()// Cuando esta activo
		{
			// Asignamos el GUISkin
			estilo = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/Moon Antonio/MDoc/Utils/MDocSkin.guiskin");

			// Asignamos el estilo del GUISkin
			if (estilo != null)
			{
				wordWrapped = estilo.GetStyle("NormalWordWrapped");
				headerText = estilo.GetStyle("HeaderText");
				seccionHeader = estilo.GetStyle("SeccionHeader");
				tituloNegrita = estilo.GetStyle("TituloNegrita");
				numVersion = estilo.GetStyle("NumVersion");
				tituloWindow = estilo.GetStyle("TituloWindow");
				btnBack = estilo.GetStyle("BtnBack");
			}
		}
		#endregion

		#region GUI
		/// <summary>
		/// <para>Interfaz de MDoc.</para>
		/// </summary>
		private void OnGUI()// Interfaz de MDoc
		{
			GUI.skin = estilo;

			EditorGUILayout.Space();

			GUILayout.BeginVertical("Box");

			EditorGUILayout.LabelField(nombreDoc, tituloWindow);

			GUILayout.Space(3);

			EditorGUILayout.LabelField(" Version " + versionDoc);

			GUILayout.Space(12);

			EditorGUILayout.BeginHorizontal();
			GUILayout.Space(smallSpace);

			if (menuActual != MenuActual.MenuPrincipal)
			{
				EditorGUILayout.BeginVertical();
				GUILayout.Space(smallSpace);
				if (GUILayout.Button("", btnBack, GUILayout.Width(80), GUILayout.Height(40)))
					BackMenuPrincipal();
				EditorGUILayout.EndVertical();
			}
			else
			{
				GUILayout.Space(80);

				GUILayout.Space(15);
				EditorGUILayout.BeginVertical();
				GUILayout.Space(14);
				EditorGUILayout.LabelField(tituloMenu, headerText);
				EditorGUILayout.EndVertical();
				GUILayout.FlexibleSpace();
				GUILayout.Space(80);
				EditorGUILayout.EndHorizontal();

				GUILayout.Space(10);

				EditorGUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				ActualizarMenu();
				GUILayout.FlexibleSpace();
			}

			EditorGUILayout.EndHorizontal();

			GUILayout.FlexibleSpace();

			GUILayout.Space(largeSpace);
			EditorGUILayout.LabelField("Moon Antonio");
			EditorGUILayout.EndVertical();
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Crea un boton.</para>
		/// </summary>
		/// <param name="nomBtn">Texto del boton.</param>
		/// <param name="menu">Menu asignado del boton.</param>
		public void Boton(string nomBtn, MenuActual menu)// Crea un boton
		{
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button(nomBtn, btnSize))
			{
				menuActual = menu;
				tituloMenu = nomBtn;
			}
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();
		}

		/// <summary>
		/// <para>Crea un boton.</para>
		/// </summary>
		/// <param name="nomBtn">Texto del boton.</param>
		/// <param name="menu">Menu asignado del boton.</param>
		/// <param name="espacio">Tiene espacio hasta el siguiente boton o va seguido.</param>
		public void Boton(string nomBtn,MenuActual menu,bool espacio)// Crea un boton
		{
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button(nomBtn, btnSize))
			{
				menuActual = menu;
				tituloMenu = nomBtn;
			}
			GUILayout.FlexibleSpace();
			EditorGUILayout.EndHorizontal();

			if(espacio) GUILayout.FlexibleSpace();
		}
		#endregion

		#region Funcional
		/// <summary>
		/// <para>Actualiza los menus.</para>
		/// </summary>
		private void ActualizarMenu()// Actualiza los menus
		{
			switch (menuActual)
			{
				case MenuActual.MenuPrincipal:
					MenuPrincipal();
					break;
				case MenuActual.Descripcion:
					MenuDescripcion();
					break;

				case MenuActual.API:
					MenuAPI();
					break;

				case MenuActual.Changelog:
					MenuChangeLog();
					break;

				case MenuActual.GitHub:
					MenuGitHub();
					break;
				default:
					MenuPrincipal();
					break;
			}
		}
		#endregion

		#region Secciones Documentacion
		#region MenuPrincipal
		/// <summary>
		/// <para>Menu principal de la documentacion.</para>
		/// </summary>
		private void MenuPrincipal()// Menu principal de la documentacion
		{
			EditorGUILayout.BeginVertical();
			GUILayout.Space(25);

			Boton("Descripcion", MenuActual.Descripcion);
			Boton("API", MenuActual.API,true);
			Boton("ChangeLog", MenuActual.Changelog);
			Boton("GitHub", MenuActual.GitHub);

			EditorGUILayout.EndVertical();
		}
		#endregion

		#region Descripcion
		/// <summary>
		/// <para>Menu descriptivo de MDoc.</para>
		/// </summary>
		private void MenuDescripcion()// Menu descriptivo de MDoc
		{

		}
		#endregion

		#region API
		/// <summary>
		/// <para>Menu de la API de MDoc.</para>
		/// </summary>
		private void MenuAPI()// Menu de la API de MDoc
		{

		}
		#endregion

		#region ChangeLog
		/// <summary>
		/// <para>Menu de los cambios realizados.</para>
		/// </summary>
		private void MenuChangeLog()// Menu de los cambios realizados
		{

		}
		#endregion

		#region GitHub
		private void MenuGitHub()
		{

		}
		#endregion
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Volver al menu principal.</para>
		/// </summary>
		private void BackMenuPrincipal()// Volver al menu principal
		{
			menuActual = MenuActual.MenuPrincipal;
			tituloMenu = "Menu Principal";
		}
		#endregion
	}

	/// <summary>
	/// <para>Metodo provisional para ver los menus.</para>
	/// </summary>
	public enum MenuActual
	{
		MenuPrincipal,
		Descripcion,
		API,
		Changelog,
		GitHub
	}
}

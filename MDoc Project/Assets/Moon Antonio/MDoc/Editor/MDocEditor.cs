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
		#region Menu
		[MenuItem("Moon Antonio/MDoc", false, 0)]
		static void InitMDoc()
		{
			Texture icono = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Moon Antonio/MDoc/Icon/mdoc.icon.png");
			GUIContent tituloContenido = new GUIContent(" MIcaros", icono);

			EditorWindow window = GetWindow<MDocEditor>();
			window.titleContent = tituloContenido;
			window.maxSize = new Vector2(500, 500);
			window.minSize = new Vector2(500, 500);
			window.Show();
		}
		#endregion
	}
}

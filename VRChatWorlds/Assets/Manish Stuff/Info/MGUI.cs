#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class MANISH : ShaderGUI
{
    private Font VrchatFont = (Font)Resources.Load(@"usuzi2");

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties)
    {
        Material material = editor.target as Material;
        Shader shader = material.shader;

        DrawBanner("My Server", "Click", "https://discord.gg/4pg9Qbz3zN");

        DrawBanner("My World", "Click", "https://vrchat.com/home/world/wrld_3f83ab2c-ad33-4291-bd94-4b15c0e56fb9");

        DrawCredits();
    }

    private void DrawBanner(string text1, string text2, string URL)
    {
        GUIStyle rateTxt = new GUIStyle { font = VrchatFont, alignment = TextAnchor.LowerRight, fontSize = 12, padding = new RectOffset(0, 1, 0, 1) };
        rateTxt.normal.textColor = new Color(0.9f, 0.9f, 0.9f);

        GUIStyle title = new GUIStyle { font = VrchatFont, alignment = TextAnchor.MiddleCenter, fontSize = 18, padding = new RectOffset(0, 1, 0, 1) };
        title.normal.textColor = new Color(0f, 0f, 0f);

        EditorGUILayout.BeginVertical("GroupBox");
        var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 35, 35);
        EditorGUI.DrawRect(rect, new Color(0.9058824f, 0.01568628f, 0.3529412f));
        EditorGUI.LabelField(rect, text2, rateTxt);
        EditorGUI.LabelField(rect, text1, title);

        if (GUI.Button(rect, "", new GUIStyle()))
        {
            Application.OpenURL(URL);
        }

        EditorGUILayout.EndVertical();
    }

    private void DrawCredits()
    {
        EditorGUILayout.BeginVertical("GroupBox");

        var TextStyle = new GUIStyle { font = VrchatFont, fontSize = 15, fontStyle = FontStyle.Italic };
		TextStyle.normal.textColor = new Color(0.9058824f, 0.01568628f, 0.3529412f);
        GUILayout.Label("If you want your own avatar", TextStyle);
		GUILayout.Space(2);
		GUILayout.Label("from scratch or ready made", TextStyle);
		GUILayout.Space(2);
		GUILayout.Label("just write to me in discord", TextStyle);
		GUILayout.Space(2);
		GUILayout.Label("and i'll make it", TextStyle);
		
        EditorGUILayout.EndVertical();
		
		EditorGUILayout.BeginHorizontal("GroupBox");
		
		Texture iconManish = (Texture)Resources.Load<Texture2D>("Avatarka");
        GUIContent buttonManish = new GUIContent(iconManish);
        if (GUILayout.Button(buttonManish, GUILayout.Width(150), GUILayout.Height(150)))
        {
            System.Diagnostics.Process.Start("https://discordapp.com/users/348787569477025792");
        }
		
		EditorGUILayout.BeginVertical("TextArea");
		
		GUILayout.Label("Discord:", TextStyle);
		GUILayout.Space(5);
		GUILayout.Label("Manish#0718", TextStyle);
        GUILayout.Space(115);
		
		EditorGUILayout.EndVertical();
		
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal("GroupBox");
		
		Texture iconXANAX = (Texture)Resources.Load<Texture2D>("XANAX");
        GUIContent buttonXANAX = new GUIContent(iconXANAX);
        if (GUILayout.Button(buttonXANAX, GUILayout.Width(150), GUILayout.Height(150)))
        {
            System.Diagnostics.Process.Start("https://discordapp.com/users/529531753979707402");
        }
		
		EditorGUILayout.BeginVertical("TextArea");
		
        GUILayout.Label("Thanks for Edit:", TextStyle);
        GUILayout.Space(5);
        GUILayout.Label("XANAX#1413", TextStyle);
		GUILayout.Space(115);
        
		EditorGUILayout.EndVertical();
        
		EditorGUILayout.EndHorizontal();
    }
}
#endif
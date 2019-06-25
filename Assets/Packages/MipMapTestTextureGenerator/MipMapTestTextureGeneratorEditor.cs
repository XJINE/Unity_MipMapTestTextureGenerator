#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public class MipMapTestTextureGeneratorEditor : EditorWindow
{
    #region Filed

    public string fileName = "MipMapTestTexture.asset";

    public int textureSize = 1024;

    public TextureFormat format = TextureFormat.ARGB32;

    public Color mipLevel0  = Color.red;
    public Color mipLevel1  = Color.green;
    public Color mipLevel2  = Color.blue;
    public Color mipLevel3  = Color.yellow;
    public Color mipLevel4  = Color.white;
    public Color mipLevel5  = Color.black;
    public Color mipLevel6  = Color.black;
    public Color mipLevel7  = Color.black;
    public Color mipLevel8  = Color.black;
    public Color mipLevel9  = Color.black;
    public Color mipLevel10 = Color.black;
    public Color mipLevel11 = Color.black;
    public Color mipLevel12 = Color.black;

    #endregion Field

    #region Method

    [MenuItem("Custom/MipMapTestTextureGenerator")]
    static void Init()
    {
        EditorWindow.GetWindow<MipMapTestTextureGeneratorEditor>
        (typeof(MipMapTestTextureGeneratorEditor).Name);
    }

    protected void OnGUI()
    {
        GUIStyle marginStyle = GUI.skin.label;
                 marginStyle.wordWrap = true;
                 marginStyle.margin   = new RectOffset(5, 5, 5, 5);

        if (GUILayout.Button("Generate"))
        {
            Color[] colors = new Color[]
            {
                mipLevel0, mipLevel1,  mipLevel2,
                mipLevel3, mipLevel4,  mipLevel5,
                mipLevel6, mipLevel7,  mipLevel8,
                mipLevel9, mipLevel10, mipLevel11,
                mipLevel12,
            };

            string path = AssetCreationHelper.CreateAssetInCurrentDirectory
                          (MipMapTestTextureGenerator.Generate(colors, this.textureSize, this.format), this.fileName);

            ShowNotification(new GUIContent("SUCCESS : " + path));
        }

        this.fileName = EditorGUILayout.TextField("File Name", this.fileName);

        this.format = (TextureFormat)EditorGUILayout.EnumPopup("Format", this.format);

        SerializedObject serializedObject = new SerializedObject(this);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("textureSize"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel0"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel1"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel2"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel3"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel4"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel5"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel6"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel7"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel8"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel9"),   true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel10"),  true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel11"),  true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("mipLevel12"),  true);
        serializedObject.ApplyModifiedProperties();
    }

    #endregion Method
}

#endif // UNITY_EDITOR
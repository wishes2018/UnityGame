using UnityEngine;
using System.Collections;
using UnityEditor;

public class GenerateMesh : MonoBehaviour {
	private int width = 100;
	private int height = 100;

	// Use this for initialization
	void Start () {
		//得到MeshFilter对象，目前是空的。
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		//得到对应的网格对象
		Mesh mesh = meshFilter.mesh;

		//三角形顶点的坐标数组
		Vector3[] vertices = new Vector3[width*height];

		//三角形顶点ID数组
		int[] triangles   = new int[6*(width-1)*(height-1)];

		//三角形三个定点坐标，为了显示清楚忽略Z轴
		int count = 0;
		for (float i = 0; i < height; i++) {
			for (float j = 0; j < width; j++) {
				float y = Mathf.PerlinNoise (j/width*5,i/height*5)*100;
				vertices[count++] = new Vector3 (j, y, i);
			}
		}

		count = 0;
		for (int i = 0; i < height - 1; i++) {
			for (int j = 0; j < width - 1; j++) {
				triangles[count++] = (i + 0) * width + (j + 0);
				triangles[count++] = (i + 1) * width + (j + 0);
				triangles[count++] = (i + 1) * width + (j + 1);
				triangles[count++] = (i + 0) * width + (j + 0);
				triangles[count++] = (i + 1) * width + (j + 1);
				triangles[count++] = (i + 0) * width + (j + 1);
			}
		}

		//绘制三角形
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();

		MeshCollider collider = GetComponent<MeshCollider> ();
		collider.sharedMesh = mesh;

		AssetDatabase.CreateAsset(mesh, "Assets/" + "Pollutant" + ".asset");
	}

	// Update is called once per frame
	void Update () {

	}
}

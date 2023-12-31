using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowAtPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private MeshRenderer mesh;
    [SerializeField]
    private float outlineScale = 1.05f;
    [SerializeField, Range(0,0.5f)]
    private float outlineCooldown = 0.3f;

    private float remainingCooldown;
    private int outlineIndex;
    private bool isOutlined = false;

    void Start()
    {
        for(int i= 0; i< mesh.materials.Length; i++)
        {
            if (mesh.materials[i].name.Contains("OutlineMaterial"))
            {
                outlineIndex = i;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOutlined)
        {
            remainingCooldown -= Time.deltaTime;
            if (remainingCooldown <= 0)
            {
                isOutlined = false;
                DeactivateGlow();
            }
        }
    }

    public void GlowObject()
    {
        mesh.materials[outlineIndex].SetFloat("_Scale", outlineScale);
        isOutlined = true;
        remainingCooldown = outlineCooldown;
    }
    public void GlowObjectNoCooldown()
    {
        mesh.materials[outlineIndex].SetFloat("_Scale", outlineScale);
        
    }

    public void DeactivateGlow()
    {
        mesh.materials[outlineIndex].SetFloat("_Scale", 0);
    }
}

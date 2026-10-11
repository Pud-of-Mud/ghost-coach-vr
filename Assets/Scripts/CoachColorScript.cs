using System.Collections.Generic;
using UnityEngine;

public class CoachColorScript : MonoBehaviour
{
    [SerializeField]
    public float exponentialConstant;

    [SerializeField]
    public GameObject mirrorPlayer;

    public float totalScore;
    public int n;

    Dictionary<string, string> materialToJoint;
    List<(Material, Transform, Transform)> couplings;

    void Awake()
    {
        materialToJoint = new Dictionary<string, string>
        {
            { "Left-Thigh", "LeftUpLeg/mixamorig:LeftLeg" },
            { "Left-Calf", "LeftUpLeg/mixamorig:LeftLeg/mixamorig:LeftFoot" },
            { "Right-Thigh", "RightUpLeg/mixamorig:RightLeg" },
            { "Right-Calf", "RightUpLeg/mixamorig:RightLeg/mixamorig:RightFoot" },
            { "Left-Bicep", "Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForearm" },
            { "Left-Forearm", "Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForearm/mixamorig:LeftHand" },
            { "Right-Bicep", "Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForearm" },
            { "Right-Forearm", "Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForearm/mixamorig:RightHand" }
        };

        couplings = new List<(Material, Transform, Transform)>();
        Material[] materials = transform.Find("Beta_Surface").GetComponent<Renderer>().materials;

        foreach (Material m in materials)
        {
            if (materialToJoint.TryGetValue(m.name, out string j))
            {
                j = "Armature/mixamorig:Hips/mixamorig:" + j;
                couplings.Add((m, transform.Find(j), mirrorPlayer.transform.Find(j)));
            }
        }
    }

    void FixedUpdate()
    {
        foreach ((Material m, Transform joint1, Transform joint2) in couplings)
        {
            float score = CalculateScore(joint1.position, joint2.position);
            totalScore += score;
            ++n;
            SetColor(m, score);
        }
    }

    void SetColor(Material limb, float score)
    {
        float maxScoreDiff = Mathf.Max(score, 1 - score);
        Color newColor = new Color((1 - score) / maxScoreDiff, score / maxScoreDiff, 0f, 1f);
        limb.color = newColor;
    }

    float CalculateScore(Vector3 position1, Vector3 position2)
    {
        float distance = (position1 - position2).magnitude;
        return Mathf.Pow(exponentialConstant, distance);
    }
}


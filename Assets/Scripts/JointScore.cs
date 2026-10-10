using UnityEngine;
using System;

public class JointScore
{
    private const float ExponentialConstant = 100;
    /**
     * Logarithmic scoring algorithm for absolute distance between joints
     * given two sets of coordinates
     * @param CoachPosition 3D coordinate showing point of coach's joint
     * @param RealPosition 3D coordinate showing point of player's joint
     * @return calculated score between 0 and 1
     */
    public float CalculateScore(Vector3 CoachPosition, Vector3 RealPosition)
    {
        float Distance = (CoachPosition - RealPosition).magnitude;
        return Math.Pow(ExponentialConstant, Distance);
    }
}


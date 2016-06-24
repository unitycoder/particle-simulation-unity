﻿using UnityEngine;

public class MidpointSolver : Solver
{
    public override void Step(ParticleSystem a_ParticleSystem, float a_DeltaTime)
	{

		int particleDimensions = a_ParticleSystem.ParticleDimensions; // = 4n
        float[] temp1 = new float[particleDimensions];
        float[] temp2 = new float[particleDimensions];
        float[] originals = new float[particleDimensions];
        a_ParticleSystem.ParticlesGetState(originals); //backup original locations and speeds

		//perform half an euler step
        a_ParticleSystem.ParticleDerivative(temp1); 
        ScaleVector(temp1, a_DeltaTime/2);
        a_ParticleSystem.ParticlesGetState(temp2); 
        AddVectors(temp1, temp2, temp2);
        a_ParticleSystem.ParticlesSetState(temp2);

		//Do the midpoint step
		a_ParticleSystem.ParticleDerivative(temp1); 
		ScaleVector(temp1, a_DeltaTime); //whole timestep
        AddVectors(originals, temp1, temp2);
        a_ParticleSystem.ParticlesSetState(temp2);
        a_ParticleSystem.Time += a_DeltaTime;
     }
}

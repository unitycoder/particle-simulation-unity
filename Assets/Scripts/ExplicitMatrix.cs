﻿using System;


public class ExplicitMatrix:Matrix
{


    private float[,] m_Values;
    private readonly int m_M, m_N;


    public ExplicitMatrix(int m, int n)
    {
        m_N = n;
        m_M = m;
        m_Values = new float[m, n];
    }

    public void setValue(int i, int j, float value)
    {
        m_Values[i, j] = value;
    }
}


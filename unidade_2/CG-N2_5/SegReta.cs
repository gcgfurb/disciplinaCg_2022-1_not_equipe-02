﻿using CG_Biblioteca;
using OpenTK.Graphics.ES10;
using OpenTK.Graphics.OpenGL;
using GL = OpenTK.Graphics.OpenGL.GL;

namespace gcgcg
{
    internal class SegReta : Objeto
    {
        public char Rotulo { get; private set; }
        private Ponto4D PontoA;
        private Ponto4D PontoB;
        private (double AnguloPontoB, double RaioPontoB) ComposicaoPontoB;
        
        
        public SegReta(char rotulo, Objeto paiRef, Ponto4D pontoA, Ponto4D pontoB) : base(rotulo, paiRef)
        {
            Rotulo = rotulo;
            PrimitivaTipo = PrimitiveType.Lines;
            PrimitivaTamanho = 5;
            PontoA = pontoA;
            PontoB = pontoB;
        }
        
        public SegReta(char rotulo, Objeto paiRef, Ponto4D pontoA, (double anguloPontoB, double raioPontoB) composicaoPontoB) : base(rotulo, paiRef)
        {
            Rotulo = rotulo;
            PrimitivaTipo = PrimitiveType.Lines;
            PrimitivaTamanho = 5;
            PontoA = pontoA;
            ComposicaoPontoB = composicaoPontoB;
            PontoB = Matematica.GerarPtosCirculo(ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB);
        }

        public void MoverParaEsquerda(uint unidadesParaMover)
        {
            var pontoParaMoverUmaUnidadeParaEsquerda = new Ponto4D(-unidadesParaMover);
            PontoA += pontoParaMoverUmaUnidadeParaEsquerda;
            PontoB += pontoParaMoverUmaUnidadeParaEsquerda;
        }
        
        public void MoverParaDireita(uint unidadesParaMover)
        {
            var pontoParaMoverUmaUnidadeParaEsquerda = new Ponto4D(unidadesParaMover);
            PontoA += pontoParaMoverUmaUnidadeParaEsquerda;
            PontoB += pontoParaMoverUmaUnidadeParaEsquerda;
        }

        public void AumentarRaioPontoB()
        {
            ComposicaoPontoB = (ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB + 1);
            PontoB = Matematica.GerarPtosCirculo(ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB) + PontoA;
        }
        
        public void DiminuirRaioPontoB()
        {
            ComposicaoPontoB = (ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB - 1);
            PontoB = Matematica.GerarPtosCirculo(ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB) + PontoA;
        }

        public void AumentarAnguloPontoB()
        {
            ComposicaoPontoB = (ComposicaoPontoB.AnguloPontoB + 1, ComposicaoPontoB.RaioPontoB);
            PontoB = Matematica.GerarPtosCirculo(ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB) + PontoA;
        }

        public void DiminuirAnguloPontoB()
        {
            ComposicaoPontoB = (ComposicaoPontoB.AnguloPontoB -1, ComposicaoPontoB.RaioPontoB);
            PontoB = Matematica.GerarPtosCirculo(ComposicaoPontoB.AnguloPontoB, ComposicaoPontoB.RaioPontoB) + PontoA;
        }
        
        
        protected override void DesenharGeometria()
        { 
            GL.Begin(PrimitivaTipo);

            GL.Vertex2(PontoA.X, PontoA.Y);
            GL.Vertex2(PontoB.X, PontoB.Y);
            
            GL.End();
        }
    }
}
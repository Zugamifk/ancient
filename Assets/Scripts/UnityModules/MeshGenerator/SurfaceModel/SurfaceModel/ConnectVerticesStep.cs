using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class ConnectVerticesStep : IStep
    {
        class CreateHalfEdgeStep : IStep
        {
            int _index;
            HalfEdge _halfEdge;
            public HalfEdge HalfEdge => _halfEdge;
            public CreateHalfEdgeStep(int index)
            {
                _index = index;
            }

            public void Do(SurfaceModelBuilder builder)
            {
                _halfEdge = builder.CreateHalfEdge(_index);
            }

            public void Undo(SurfaceModelBuilder builder)
            {
                builder.RemoveHalfEdge(_halfEdge);
            }
        }
        class CreateEdgeStep : IStep
        {
            CreateHalfEdgeStep _h0, _h1;
            Edge _edge;
            public CreateEdgeStep(CreateHalfEdgeStep h0, CreateHalfEdgeStep h1)
            {
                _h0 = h0;
                _h1 = h1;
            }

            public void Do(SurfaceModelBuilder builder)
            {
                _edge = builder.CreateEdge(_h0.HalfEdge, _h1.HalfEdge);
            }

            public void Undo(SurfaceModelBuilder builder)
            {
                builder.RemoveEdge(_edge);
            }
        }

        int _i0, _i1;
        Edge _edge;

        public static IEnumerable<IStep> InSubsteps(int i0, int i1)
        {
            var he0 = new CreateHalfEdgeStep(i0);
            yield return he0;
            var he1 = new CreateHalfEdgeStep(i1);
            yield return he1;
            var edge = new CreateEdgeStep(he0, he1);
            yield return edge;
        }

        public ConnectVerticesStep(int i0, int i1) {
            _i0 = i0;
            _i1 = i1;
        }

        public void Do(SurfaceModelBuilder builder)
        {
            _edge = builder.ConnectVertices(_i0, _i1);
        }

        public void Undo(SurfaceModelBuilder builder)
        {
            builder.RemoveEdge(_edge);
        }
    }
}

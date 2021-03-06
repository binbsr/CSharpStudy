﻿using System;

namespace _7_0
{
    class D_IC_Pattern_Matching
    {
        public static double ComputeArea(object shape)
        {
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;

            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }

        public static double ComputeAreaModernSwitch(object shape)
        {
            // switch statement using the type pattern instead traditional constant (numeric and string) pattern

            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height / 2;
                case Rectangle r:
                    return r.Height * r.Length;
                case null:
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }

        static object CreateShape(string shapeDescription)
        {
            switch (shapeDescription)
            {
                case "circle":
                    return new Circle(2);

                case "square":
                    return new Square(4);

                case "large-circle":
                    return new Circle(12);

                case var o when (o?.Trim().Length ?? 0) == 0:                    
                    return null;
                default:
                    return "invalid shape description";
            }
        }
    }

    public class Square
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }
    }
    public class Circle
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    public struct Rectangle
    {
        public double Length { get; }
        public double Height { get; }

        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
    }
    public class Triangle
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
}

//Pattern matching supports is expressions and switch expressions.
﻿#region Copyright (C) 2009 by Pavel Savara

/*
This file is part of tools for jni4net - bridge between Java and .NET
http://jni4net.sourceforge.net/

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Collections.Generic;
using java.lang;
using java.lang.reflect;
using NUnit.Framework;
using Byte=java.lang.Byte;
using Object=java.lang.Object;
using String=java.lang.String;

namespace net.sf.jni4net.test
{
    [TestFixture]
    public class BasicTests : TestBase
    {
        [Test]
        public void ArrayTest()
        {
            String s1 = env.NewString("test");
            Class clazz = s1.getClass();
            Method[] methods = clazz.getMethods();
            Assert.Greater(methods.Length, 20);
            foreach (Method method in methods)
            {
                Class returnType = method.getReturnType();
                Console.WriteLine(method + " " + returnType);
            }
        }

        [Test]
        public void ByteConstructor()
        {
            var b = new Byte(7);
            byte value = b.byteValue();
            Assert.AreEqual(7, value);
        }

        [Test]
        public void CreateEquals()
        {
            var outStream = env.GetStaticField<Object>("java/lang/System", "out", "Ljava/io/PrintStream;");
            var outStream2 = env.GetStaticField<Object>("java/lang/System", "out", "Ljava/io/PrintStream;");
            Assert.AreEqual(outStream2, outStream);
            String s1 = env.NewString("test");
            String s2 = env.NewString("test");
            Assert.AreNotSame(s1, s2);
            Assert.AreEqual(s1, s2);
        }

        [Test]
        public void Dispose()
        {
            String s1 = env.NewString("test");
            s1.Dispose();
        }

        [Test]
        [Explicit]
        public void HeavyAlloc()
        {
            DateTime start = DateTime.Now;
            var list = new List<String>();
            for (int i = 0; i < 1000000; i++)
            {
                String s3 = "test" + i;
                list.Add(s3);
            }

            foreach (String s in list)
            {
                s.Dispose();
            }
            DateTime end = DateTime.Now;

            Console.WriteLine(end - start);
        }

        [Test]
        [Explicit]
        public void HeavyCall()
        {
            var sb = new StringBuilder();
            DateTime start = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                sb.append('a');
            }
            DateTime end = DateTime.Now;

            Console.WriteLine(end - start);
        }


        [Test]
        public void Length()
        {
            String s1 = env.NewString("test");
            Assert.AreEqual(4, s1.length());
        }

        [Test]
        [ExpectedException(typeof (NoClassDefFoundError))]
        public void BadClassThrow()
        {
            env.FindClass("asdfadf");
        }


        [Test]
        public void PrimitiveClass()
        {
            Class clazz = env.FindClass("java/lang/Integer");
            var intType = clazz.GetFieldValue<Object>("TYPE", "Ljava/lang/Class;");
            Class intType2 = Class.getPrimitiveClass("int");
            Assert.AreEqual(intType2, intType);
        }

        [Test]
        public void Print()
        {
            var outStream = env.GetStaticField<Object>("java/lang/System", "out", "Ljava/io/PrintStream;");
            outStream.Invoke("println", "(Ljava/lang/String;)V", "message from Java");
        }


        [Test]
        public void StaticString()
        {
            String s1 = env.NewString("test");
            Assert.AreEqual(4, s1.length());
        }

        [Test]
        public void StringConstructor()
        {
            var s = new String("Tetsts");
            Assert.IsTrue("Tetsts".Equals(s));
            Assert.IsTrue(s.Equals("Tetsts"));
        }

        [Test]
        public void SystemOut()
        {
            java.lang.System.@out.println("Test");
        }

        public static void Main()
        {
            //var test =  new BridgeTest();
            //test.Setup();
            //test.HeavyAlloc();

            var test = new CallBackTest();
            test.Setup();
            test.HeavyCallMeFromJava();
        }
    }
}
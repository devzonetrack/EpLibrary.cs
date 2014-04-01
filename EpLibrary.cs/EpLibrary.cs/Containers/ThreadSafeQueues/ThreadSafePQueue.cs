﻿/*! 
@file ThreadSafePQueue.cs
@author Woong Gyu La a.k.a Chris. <juhgiyo@gmail.com>
		<http://github.com/juhgiyo/eplibrary.cs>
@date April 01, 2014
@brief ThreadSafePQueue Interface
@version 2.0

@section LICENSE

The MIT License (MIT)

Copyright (c) 2014 Woong Gyu La <juhgiyo@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

@section DESCRIPTION

A ThreadSafePQueue Class.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EpLibrary.cs
{
    /// <summary>
    /// A class for Thread Safe Priority Queue.
    /// </summary>
    /// <typeparam name="DataType">the element type</typeparam>
    public class ThreadSafePQueue<DataType>:ThreadSafeQueue<DataType> where DataType : IComparable<DataType>
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ThreadSafePQueue():base()
        {
            
        }

        /// <summary>
        /// Default copy constructor
        /// </summary>
        /// <param name="b">object to copy from</param>
		public ThreadSafePQueue(ThreadSafePQueue<DataType> b):base(b)
        {

        }

        ~ThreadSafePQueue() { }

        /// <summary>
        /// Insert the new item into the priority queue.
        /// </summary>
        /// <param name="data">The inserting data.</param>
        public override void Push(DataType data)
        {
            lock(m_queueLock)
            {
		        if(m_queue.Count>0)
		        {
			        int retIdx=m_queue.BinarySearch(data);
                    if (retIdx < 0)
                        m_queue.Insert(~retIdx, data);
                    else
                        Debug.Assert(false, "Same Object already in the queue!");
		        }
		        else
		        {
			        m_queue.Add(data);
		        }
            }
		    
        }
    }
}

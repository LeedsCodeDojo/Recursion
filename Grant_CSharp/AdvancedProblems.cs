using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Recursion_Solutions_CSharp {
    /// <summary>
    /// Solutions to some of the Advanced problems
    /// </summary>
    public static class AdvancedProblems {
        public static bool even(int num) { return num % 2 == 0; }

        public static void fibonacci_continuations(int n, Action<int> continuation) {
            if( n < 2 ){
                continuation.Invoke(1);
            }
            else {
                fibonacci_continuations(n - 1, minus1result => {
                    fibonacci_continuations(n - 2, minus2result => {
                        continuation.Invoke(minus1result + minus2result);
                    });
                });
            }
        }

        public static void ackermann_continuations(int m, int n, Action<int> continuation) {
            if (m == 0) {
                continuation.Invoke(n + 1);
            }
            else if (n == 0) {
                ackermann_continuations(m - 1, 1, result => continuation.Invoke(result));
            }
            else {
                ackermann_continuations(m, n - 1, outerResult => {
                    ackermann_continuations(m - 1, outerResult, innerResult => {
                        continuation.Invoke(innerResult);
                    });
                });
            }
        }
    }
}

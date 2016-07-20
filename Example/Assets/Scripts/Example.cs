using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;

public class Example : MonoBehaviour
{
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate void ProgressCallback(int value);

    [DllImport("Callback")]
    static extern void StdCallback(ProgressCallback callback);

    [DllImport("Callback")]
    static extern void ThreadCallback(ProgressCallback callback);

    void Start ()
    {
        Debug.LogFormat("Start, Main ThreadID: {0}", Thread.CurrentThread.ManagedThreadId);

        StdCallback(this.OnStdCallback);
        ThreadCallback(this.OnThreadCallback);
    }

    void OnStdCallback(int n)
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        Debug.LogFormat("StdCallback: {0}, ThreadID: {1}", n, threadId);
        this.StartCoroutine(this.EmptyCoroutine());
    }

    void OnThreadCallback(int n)
    {
        var threadId = Thread.CurrentThread.ManagedThreadId;
        Debug.LogFormat("ThreadCallback: {0}, ThreadID: {1}", n, threadId);
        this.StartCoroutine(this.EmptyCoroutine());
    }

    IEnumerator EmptyCoroutine()
    {
        yield break;
    }
}

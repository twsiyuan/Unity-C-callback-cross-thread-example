#include "Callback.h"
#include "pthread.h"
#include <stdlib.h>
#include <time.h>
#include <Windows.h>

BOOL APIENTRY DllMain(HANDLE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
	srand(time(NULL));
	return TRUE;
}

DLL_API void StdCallback(ProgressCallback callback)
{
	callback(rand() % 1000);
}

void *doThread(void* args)
{
	ProgressCallback callback = (ProgressCallback)args;
	callback(rand() % 1000);
	return NULL;
}

DLL_API void ThreadCallback(ProgressCallback callback)
{
	pthread_t t;
	pthread_create(&t, NULL, doThread, (void*)callback);
	pthread_join(t, NULL);
}
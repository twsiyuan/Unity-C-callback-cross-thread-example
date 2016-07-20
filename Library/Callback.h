#ifndef DLL_EXPOTER_H
#define DLL_EXPOTER_H

#ifdef WIN32
	#define DLL_API __declspec(dllexport)
#else
	#define DLL_API extern
#endif

#ifdef __cplusplus
extern "C" {
#endif
	typedef void (__stdcall * ProgressCallback)(int);

	DLL_API void StdCallback(ProgressCallback callback);
	DLL_API void ThreadCallback(ProgressCallback callback);

#ifdef __cplusplus
}
#endif
#endif
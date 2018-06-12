/****************************** Module Header ******************************\
* Module Name:	NativeVideoEncoder.h
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* The entry point of the dll.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#include "stdafx.h"
#include "NativeVideoEncoder.h"
#include "VideoEncoder.h"
#include "XmlParser.h"

// Remove this in production code.
//#define DEBUG 1

#ifdef DEBUG
#include "UnitTest.h"
#endif

// This is an example of an exported function.
NATIVEVIDEOENCODER_API HRESULT EncoderVideo(wchar_t* pInputFile, wchar_t* pOutputFile, wchar_t* pLogFile)
{
	//#ifdef DEBUG
	//UnitTest* unitTest = new UnitTest();
	//HRESULT hr = unitTest->DoUnitTest();
	//delete unitTest;
	//return hr;
	//#endif

	HRESULT hr = S_OK;
	VideoEncoder* encoder = new VideoEncoder();
	encoder->SetInputFile(pInputFile);
	encoder->SetOutputFile(pOutputFile);
	encoder->SetLogFile(pLogFile);
	hr = encoder->Encode();

	return hr;
	//VideoEncoder* videoEncoder = new VideoEncoder();
	//return videoEncoder->Encode();	
}

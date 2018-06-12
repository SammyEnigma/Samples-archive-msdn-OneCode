/****************************** Module Header ******************************\
* Module Name:	Photo.h
* Project: NativeVideoEncoder
* Copyright (c) Microsoft Corporation.
* 
* A model class representing a photo.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#pragma once
#include "stdafx.h"
#include "string"
#include "TransitionBase.h"

using namespace std;

class Photo
{
public:
	Photo(void);
	~Photo(void);

	wstring GetFile()
	{
		return this->m_file;
	}

	void SetFile(wstring value)
	{
		this->m_file = value;
	}

	int GetPhotoDuration()
	{
		return this->m_photoDuration;
	}

	void SetPhotoDuration(int value)
	{
		this->m_photoDuration = value;
	}

	// Currently we only allow a single transition on a phone.
	// This may be changed in the future.
	wstring GetTransitionName()
	{
		return this->m_transitionName;
	}

	void SetTransitionName(wstring value)
	{
		this->m_transitionName = value;
	}

	int GetTransitionDuration()
	{
		return this->m_transitionDuration;
	}

	void SetTransitionDuration(int value)
	{
		this->m_transitionDuration = value;
	}

	TransitionBase* GetTransition()
	{
		return this->m_pTransition;
	}

	void SetTransition(TransitionBase* value)
	{
		if (this->m_pTransition != nullptr)
		{
			delete this->m_pTransition;
		}
		this->m_pTransition = value;
	}

private:
	wstring m_file;
	int m_photoDuration;
	wstring m_transitionName;
	int m_transitionDuration;
	TransitionBase* m_pTransition;
};


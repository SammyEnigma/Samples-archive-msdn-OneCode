﻿'********************************* Module Header *********************************\
' Module Name: TransitionBase.vb
' Project: VideoStoryCreator
' Copyright (c) Microsoft Corporation.
' 
' A base class that provides some default implementation of ITransition.
' A transition class can inherite this base class,
' or it can implement ITransition directly.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'***************************************************************************/



Imports System.Xml.Linq

Public MustInherit Class TransitionBase
    Implements ITransition
    


    Public Event TransitionCompleted(sender As Object, e As System.EventArgs) Implements ITransition.TransitionCompleted

    Public MustOverride ReadOnly Property Name() As String Implements ITransition.Name
    Public Overridable Property ForegroundElement() As FrameworkElement Implements ITransition.ForegroundElement

        Get
            Return m_ForegroundElement
        End Get
        Set(value As FrameworkElement)
            m_ForegroundElement = value
        End Set
    End Property
    Private m_ForegroundElement As FrameworkElement
    Public Overridable Property BackgroundElement() As FrameworkElement Implements ITransition.BackgroundElement

        Get
            Return m_BackgroundElement
        End Get
        Set(value As FrameworkElement)
            m_BackgroundElement = value
        End Set
    End Property
    Private m_BackgroundElement As FrameworkElement
    Public Overridable Property TransitionDuration() As TimeSpan Implements ITransition.TransitionDuration
        Get
            Return m_TransitionDuration
        End Get
        Set(value As TimeSpan)
            m_TransitionDuration = value
        End Set
    End Property
    Private m_TransitionDuration As TimeSpan

    Public Overridable ReadOnly Property ImageZIndexModified() As Boolean Implements ITransition.ImageZIndexModified
        Get
            Return False
        End Get
    End Property

    Public MustOverride Sub Begin() Implements ITransition.Begin

    Public MustOverride Sub [Stop]() Implements ITransition.Stop


    Public Overridable Sub Save(transitionElement As XElement) Implements ITransition.Save
        transitionElement.Add(New XAttribute("Name", Me.Name))
        transitionElement.Add(New XAttribute("Duration", Me.TransitionDuration.TotalSeconds))
    End Sub

    Public Shared Function Load(transitionElement As XElement) As ITransition
        Dim name As String = transitionElement.Attribute("Name").Value
        Dim transition As ITransition = TransitionFactory.CreateTransition(name)
        If transition IsNot Nothing Then
            Try
                Dim durationString As String = transitionElement.Attribute("Duration").Value
                Dim duration As Integer = Integer.Parse(durationString)
                transition.TransitionDuration = TimeSpan.FromSeconds(duration)

                ' Todo: Need to review the design. We don't want to expose LoadChild on ITransition.
                ' But convert ITransition to TransitionBase and invoke LoadChild may not be a very good design.
                DirectCast(transition, TransitionBase).LoadChild(transitionElement)
            Catch
                Throw New Exception("Unable to load the transition.")
            End Try
        End If
        Return transition
    End Function

    Protected Overridable Sub LoadChild(transitionElement As XElement)
    End Sub

    Public MustOverride Function Clone() As ITransition Implements ITransition.Clone

End Class

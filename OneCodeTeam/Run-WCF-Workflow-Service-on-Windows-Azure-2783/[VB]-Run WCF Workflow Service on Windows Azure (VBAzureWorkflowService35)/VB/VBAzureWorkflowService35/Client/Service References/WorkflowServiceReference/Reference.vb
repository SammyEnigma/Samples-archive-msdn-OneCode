﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4927
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace WorkflowServiceReference
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="WorkflowServiceReference.IProcessDataWorkflow", SessionMode:=System.ServiceModel.SessionMode.NotAllowed)>  _
    Public Interface IProcessDataWorkflow
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IProcessDataWorkflow/ProcessData", ReplyAction:="http://tempuri.org/IProcessDataWorkflow/ProcessDataResponse")>  _
        Function ProcessData(ByVal value As Integer) As String
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Public Interface IProcessDataWorkflowChannel
        Inherits WorkflowServiceReference.IProcessDataWorkflow, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")>  _
    Partial Public Class ProcessDataWorkflowClient
        Inherits System.ServiceModel.ClientBase(Of WorkflowServiceReference.IProcessDataWorkflow)
        Implements WorkflowServiceReference.IProcessDataWorkflow
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function ProcessData(ByVal value As Integer) As String Implements WorkflowServiceReference.IProcessDataWorkflow.ProcessData
            Return MyBase.Channel.ProcessData(value)
        End Function
    End Class
End Namespace

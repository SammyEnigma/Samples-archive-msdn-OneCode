﻿
'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.ComponentModel
Imports System.Data.EntityClient
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


<Assembly: EdmSchemaAttribute("5e5e3f44-2615-4e70-807d-3a2d7afb81e6")>
#Region "Contexts"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
Public Partial Class EFDemoDBEntities
    Inherits ObjectContext

    #Region "Constructors"

    ''' <summary>
    ''' Initializes a new EFDemoDBEntities object using the connection string found in the 'EFDemoDBEntities' section of the application configuration file.
    ''' </summary>
    Public Sub New()
        MyBase.New("name=EFDemoDBEntities", "EFDemoDBEntities")
        MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new EFDemoDBEntities object.
    ''' </summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "EFDemoDBEntities")
        MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new EFDemoDBEntities object.
    ''' </summary>
    Public Sub New(ByVal connection As EntityConnection)
        MyBase.New(connection, "EFDemoDBEntities")
        MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    #End Region

    #Region "Partial Methods"

    Partial Private Sub OnContextCreated()
    End Sub

    #End Region

    #Region "ObjectSet Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    Public ReadOnly Property People() As ObjectSet(Of Person)
        Get
            If (_People Is Nothing) Then
                _People = MyBase.CreateObjectSet(Of Person)("People")
            End If
            Return _People
        End Get
    End Property

    Private _People As ObjectSet(Of Person)

    #End Region

    #Region "AddTo Methods"

    ''' <summary>
    ''' Deprecated Method for adding a new object to the People EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
    ''' </summary>
    Public Sub AddToPeople(ByVal person As Person)
        MyBase.AddObject("People", person)
    End Sub

    #End Region

    #Region "Function Imports"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    ''' <param name="name">No Metadata Documentation available.</param>
    ''' <param name="description">No Metadata Documentation available.</param>
    ''' <param name="iD">No Metadata Documentation available.</param>
    Public Function InsertPerson(name As Global.System.String, description As Global.System.String, iD As ObjectParameter) As Integer
        Dim nameParameter As ObjectParameter
        If (name IsNot Nothing)
            nameParameter = New ObjectParameter("Name", name)
        Else
            nameParameter = New ObjectParameter("Name", GetType(Global.System.String))
        End If

        Dim descriptionParameter As ObjectParameter
        If (description IsNot Nothing)
            descriptionParameter = New ObjectParameter("Description", description)
        Else
            descriptionParameter = New ObjectParameter("Description", GetType(Global.System.String))
        End If

        Return MyBase.ExecuteFunction("InsertPerson", nameParameter, descriptionParameter, iD)

    End Function

    #End Region

End Class

#End Region

#Region "Entities"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
<EdmEntityTypeAttribute(NamespaceName:="EFDemoDBModel", Name:="Person")>
<Serializable()>
<DataContractAttribute(IsReference:=True)>
Public Partial Class Person
    Inherits EntityObject
    #Region "Factory Method"

    ''' <summary>
    ''' Create a new Person object.
    ''' </summary>
    ''' <param name="id">Initial value of the Id property.</param>
    ''' <param name="name">Initial value of the Name property.</param>
    Public Shared Function CreatePerson(id As Global.System.Int32, name As Global.System.String) As Person
        Dim person as Person = New Person
        person.Id = id
        person.Name = name
        Return person
    End Function

    #End Region

    #Region "Primitive Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Id() As Global.System.Int32
        Get
            Return _Id
        End Get
        Set
            If (_Id <> Value) Then
                OnIdChanging(value)
                ReportPropertyChanging("Id")
                _Id = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("Id")
                OnIdChanged()
            End If
        End Set
    End Property

    Private _Id As Global.System.Int32
    Private Partial Sub OnIdChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnIdChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Name() As Global.System.String
        Get
            Return _Name
        End Get
        Set
            OnNameChanging(value)
            ReportPropertyChanging("Name")
            _Name = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("Name")
            OnNameChanged()
        End Set
    End Property

    Private _Name As Global.System.String
    Private Partial Sub OnNameChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnNameChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property Description() As Global.System.String
        Get
            Return _Description
        End Get
        Set
            OnDescriptionChanging(value)
            ReportPropertyChanging("Description")
            _Description = StructuralObject.SetValidValue(value, true)
            ReportPropertyChanged("Description")
            OnDescriptionChanged()
        End Set
    End Property

    Private _Description As Global.System.String
    Private Partial Sub OnDescriptionChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnDescriptionChanged()
    End Sub

    #End Region

End Class

#End Region



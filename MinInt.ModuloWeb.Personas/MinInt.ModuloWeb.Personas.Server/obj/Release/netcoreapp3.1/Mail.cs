// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/mail.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Emails {

  /// <summary>Holder for reflection information generated from Protos/mail.proto</summary>
  public static partial class MailReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/mail.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MailReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFQcm90b3MvbWFpbC5wcm90bxIEbWFpbCJZCgtNYWlsUmVxdWVzdBIVCg1j",
            "dWVudGFEZXN0aW5vGAEgASgJEg4KBm5vbWJyZRgCIAEoCRIQCghjb2RFbWFp",
            "bBgDIAEoBRIRCglpZFBlcnNvbmEYBCABKAUiKwoJTWFpbFJlcGx5Eh4KBWVy",
            "cm9yGAEgASgOMg8ubWFpbC5FcnJvckNvZGUqRQoJRXJyb3JDb2RlEggKBE5v",
            "bmUQABITCg5FbWFpbE5vRW52aWFkbxCsAhIZChRTZXJ2aWRvck5vRGlzcG9u",
            "aWJsZRCQAzJCCgZNYWlsZXISOAoSTWFpbENoYWdlZFBhc3N3b3JkEhEubWFp",
            "bC5NYWlsUmVxdWVzdBoPLm1haWwuTWFpbFJlcGx5QgmqAgZFbWFpbHNiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Emails.ErrorCode), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Emails.MailRequest), global::Emails.MailRequest.Parser, new[]{ "CuentaDestino", "Nombre", "CodEmail", "IdPersona" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Emails.MailReply), global::Emails.MailReply.Parser, new[]{ "Error" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum ErrorCode {
    [pbr::OriginalName("None")] None = 0,
    [pbr::OriginalName("EmailNoEnviado")] EmailNoEnviado = 300,
    [pbr::OriginalName("ServidorNoDisponible")] ServidorNoDisponible = 400,
  }

  #endregion

  #region Messages
  public sealed partial class MailRequest : pb::IMessage<MailRequest> {
    private static readonly pb::MessageParser<MailRequest> _parser = new pb::MessageParser<MailRequest>(() => new MailRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MailRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Emails.MailReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MailRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MailRequest(MailRequest other) : this() {
      cuentaDestino_ = other.cuentaDestino_;
      nombre_ = other.nombre_;
      codEmail_ = other.codEmail_;
      idPersona_ = other.idPersona_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MailRequest Clone() {
      return new MailRequest(this);
    }

    /// <summary>Field number for the "cuentaDestino" field.</summary>
    public const int CuentaDestinoFieldNumber = 1;
    private string cuentaDestino_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CuentaDestino {
      get { return cuentaDestino_; }
      set {
        cuentaDestino_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "nombre" field.</summary>
    public const int NombreFieldNumber = 2;
    private string nombre_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Nombre {
      get { return nombre_; }
      set {
        nombre_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "codEmail" field.</summary>
    public const int CodEmailFieldNumber = 3;
    private int codEmail_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CodEmail {
      get { return codEmail_; }
      set {
        codEmail_ = value;
      }
    }

    /// <summary>Field number for the "idPersona" field.</summary>
    public const int IdPersonaFieldNumber = 4;
    private int idPersona_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int IdPersona {
      get { return idPersona_; }
      set {
        idPersona_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MailRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MailRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CuentaDestino != other.CuentaDestino) return false;
      if (Nombre != other.Nombre) return false;
      if (CodEmail != other.CodEmail) return false;
      if (IdPersona != other.IdPersona) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CuentaDestino.Length != 0) hash ^= CuentaDestino.GetHashCode();
      if (Nombre.Length != 0) hash ^= Nombre.GetHashCode();
      if (CodEmail != 0) hash ^= CodEmail.GetHashCode();
      if (IdPersona != 0) hash ^= IdPersona.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (CuentaDestino.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CuentaDestino);
      }
      if (Nombre.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Nombre);
      }
      if (CodEmail != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(CodEmail);
      }
      if (IdPersona != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(IdPersona);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CuentaDestino.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CuentaDestino);
      }
      if (Nombre.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Nombre);
      }
      if (CodEmail != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(CodEmail);
      }
      if (IdPersona != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(IdPersona);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MailRequest other) {
      if (other == null) {
        return;
      }
      if (other.CuentaDestino.Length != 0) {
        CuentaDestino = other.CuentaDestino;
      }
      if (other.Nombre.Length != 0) {
        Nombre = other.Nombre;
      }
      if (other.CodEmail != 0) {
        CodEmail = other.CodEmail;
      }
      if (other.IdPersona != 0) {
        IdPersona = other.IdPersona;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            CuentaDestino = input.ReadString();
            break;
          }
          case 18: {
            Nombre = input.ReadString();
            break;
          }
          case 24: {
            CodEmail = input.ReadInt32();
            break;
          }
          case 32: {
            IdPersona = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class MailReply : pb::IMessage<MailReply> {
    private static readonly pb::MessageParser<MailReply> _parser = new pb::MessageParser<MailReply>(() => new MailReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MailReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Emails.MailReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MailReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MailReply(MailReply other) : this() {
      error_ = other.error_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MailReply Clone() {
      return new MailReply(this);
    }

    /// <summary>Field number for the "error" field.</summary>
    public const int ErrorFieldNumber = 1;
    private global::Emails.ErrorCode error_ = global::Emails.ErrorCode.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Emails.ErrorCode Error {
      get { return error_; }
      set {
        error_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MailReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MailReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Error != other.Error) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Error != global::Emails.ErrorCode.None) hash ^= Error.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Error != global::Emails.ErrorCode.None) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Error);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Error != global::Emails.ErrorCode.None) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Error);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MailReply other) {
      if (other == null) {
        return;
      }
      if (other.Error != global::Emails.ErrorCode.None) {
        Error = other.Error;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Error = (global::Emails.ErrorCode) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
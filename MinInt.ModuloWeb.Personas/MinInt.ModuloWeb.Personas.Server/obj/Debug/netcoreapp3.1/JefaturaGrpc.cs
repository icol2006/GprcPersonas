// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/jefatura.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Jefaturas {
  public static partial class jefatura
  {
    static readonly string __ServiceName = "jefatura.jefatura";

    static readonly grpc::Marshaller<global::Jefaturas.JefaturaRequest> __Marshaller_jefatura_JefaturaRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Jefaturas.JefaturaRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Jefaturas.JefaturaReply> __Marshaller_jefatura_JefaturaReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Jefaturas.JefaturaReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Jefaturas.JefaturaRequest, global::Jefaturas.JefaturaReply> __Method_Create = new grpc::Method<global::Jefaturas.JefaturaRequest, global::Jefaturas.JefaturaReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Create",
        __Marshaller_jefatura_JefaturaRequest,
        __Marshaller_jefatura_JefaturaReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Jefaturas.JefaturaReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of jefatura</summary>
    [grpc::BindServiceMethod(typeof(jefatura), "BindService")]
    public abstract partial class jefaturaBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Jefaturas.JefaturaReply> Create(global::Jefaturas.JefaturaRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(jefaturaBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Create, serviceImpl.Create).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, jefaturaBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Create, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Jefaturas.JefaturaRequest, global::Jefaturas.JefaturaReply>(serviceImpl.Create));
    }

  }
}
#endregion

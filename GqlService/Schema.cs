using System;
using HotChocolate;
using HotChocolate.Types;
using AnyType = HotChocolate.Types.AnyType;
using BooleanType = HotChocolate.Types.BooleanType;
using StringType = HotChocolate.Types.StringType;

namespace GqlService
{
    public class Schema
    {
        public static ISchema Create()
        {
            return SchemaBuilder.New()
                .AddMutationType<Mutation>()
                .AddObjectType<DataReferencesQuery>(
                    b => 
                        b.Field(q => q.Read(default))
                         .Argument("name", a => a.Type<StringType>())
                    .Type<AnyType>())
                .AddObjectType<Mutation.DataReferenceMutation>(b =>
                    b.Field(m => m.Write(default, default))
                        .Type<BooleanType>()
                        .Argument("name", a => a.Type<StringType>())
                        .Argument("value", a => a.Type<AnyType>())
                        .Resolver(ctx => ctx.Parent<Mutation.DataReferenceMutation>().Write(ctx.Argument<String>("name"), ctx.Argument<object>("value"))))
                .AddSubscriptionType<Subscription>()
                .AddObjectType<ReferenceValueChange>(d => d.BindFieldsImplicitly().Field(o => o.Value).Type<AnyType>())
                .AddQueryType<Query>()
                .ModifyOptions(o => o.RemoveUnreachableTypes = true)
                .Create();
        }
    }
}
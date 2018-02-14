using System;
namespace Astra.Facades
{
    public interface IRetrieveMasterDataCommand
    {
        CommandResult<RetrieveMasterDataResult> Execute(MasterDataArguments args);
    }
}

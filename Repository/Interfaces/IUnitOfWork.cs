namespace Repository.Interfaces
{
    public interface IUnitOfWork
    {
        // Ejemplos de repositorios a agregar
        /*
        IDataTypeRepository DataTypeRepository { get; }
        IEquivalenceRepository EquivalenceRepository { get; }
        IMessageMappingRepository MessageMappingRepository { get; }
        IMessageRepository MessageRepository { get; }
        IMessageTypeRepository MessageTypeRepository { get; }
        INodeRepository NodeRepository { get; }
        INodeTransformationRepository NodeTransformationRepository { get; }
        ITransformationRepository TransformationRepository { get; }
        INodeMappingRepository NodeMappingRepository { get; }
        ILogMessageRepository LogMessageRepository { get; }
        IDestinataryRepository DestinataryRepository { get; }
        ISendTypeRepository SendTypeRepository { get; }
        IVerbRepository VerbRepository { get; }
        IAgentRepository AgentRepository { get; }
        ITypeServiceDestinationRepository TypeServiceDestinationRepository { get; }
        IHeaderMessageRepository HeaderMessageRepository { get; }
        */
        int Complete();
    }
}

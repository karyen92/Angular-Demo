using System;
using Demo.Core.Validators;

namespace Demo.Core.Command
{
    public abstract class AbstractCommand<TInput, TOutput>
        where TInput : class
        where TOutput : class
    {
        private Action PreExecution = () => { };
        private Action PostExecution = () => { };
        protected TInput InputModel;
        private TOutput OutputModel;

        public void RegisterPreExecution(Action preExecution)
        {
            PreExecution += preExecution;
        }

        public void RegisterPostExecution(Action postExecution)
        {
            PostExecution += postExecution;
        }

        public TOutput GetOutput()
        {
            return OutputModel;
        }

        protected abstract TOutput Execution();

        public void Execute(TInput model)
        {
            InputModel = model;
            OutputModel = Execution();
        }
    }
}

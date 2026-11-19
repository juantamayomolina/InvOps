using System;
using System.Collections.Generic;
using System.Text;

namespace InvOps.UI.Pub
{
    public interface ISubscriber
    {
        // Receive update from subject/publisher
        void Update(IPublisher publisher);
    }

    public interface IPublisher
    {
        // Attach an observer to the subject.
        void Attach(ISubscriber subscriber);

        // Detach an observer from the subject.
        void Detach(ISubscriber subscriber);

        // Notify all observers about an event.
        void Notify();
    }
    public class ResultadosPub : IPublisher
    {
        
        private List<ISubscriber> _subscribers = new List<ISubscriber>();
        public double resMaximax { get; set; } = -0;
        public string desMaximax { get; set; } = "";
        public double resWald { get; set; } = -0;
        public string desWald { get; set; } = "";
        public double resLaplace { get; set; } = -0;
        public string desLaplace { get; set; } = "";
        public double resHurwicz { get; set; } = -0;
        public string desHurwicz { get; set; } = "";
        public double resSavage { get; set; } = -0;
        public string desSavage { get; set; } = "";
        public double resValorEsperado { get; set; } = -0;
        public string desValorEsperado { get; set; } = "";
        public double resMaximaProbabilidad { get; set; } = -0;
        public string desMaximaProbabilidad { get; set; } = "";

        public void Attach(ISubscriber subscriber)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            this._subscribers.Remove(subscriber);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(this);
            }
        }

        public void ActualizarResultado(string tipoRes, double res, string decision)
        {
            //enum tipoResultado { Maximax, Wald, Laplace, Hurwicz, Savage }
            switch (tipoRes)
            {
                case "Maximax":
                    resMaximax = res;
                    desMaximax = decision;
                    this.Notify();
                    break;
                case "Wald":
                    resWald = res;
                    desWald = decision;
                    this.Notify();
                    break;
                case "Laplace":
                    resLaplace = res;
                    desLaplace = decision;
                    this.Notify();
                    break;
                case "Hurwicz":
                    resHurwicz = res;
                    desHurwicz = decision;
                    this.Notify();
                    break;
                case "Savage":
                    resSavage = res;
                    desSavage = decision;
                    this.Notify();
                    break;
                case "ValorEsperado":
                    resValorEsperado = res;
                    desValorEsperado = decision; 
                    this.Notify();
                    break;
                case "MaximaProbabilidad":
                    resMaximaProbabilidad= res;
                    desMaximaProbabilidad= decision;
                    this.Notify();
                    break;
                default:
                    break;
            }
        }
    }
}

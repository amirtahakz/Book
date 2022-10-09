using Common.Domain;
using Common.Domain.Exceptions;
using Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        private Wallet()
        {

        }
        public Wallet(long price, string description, bool isFinally, WalletType type)
        {
            if (price < 500)
                throw new InvalidDomainDataException();

            Price = price;
            Description = description;
            IsFinally = isFinally;
            Type = type;
            if (isFinally)
                FinallyDate = DateTime.Now;
        }

        public long Price { get; private set; }
        public WalletType Type { get; private set; }
        public string Description { get; private set; }
        public Guid UserId { get; internal set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }

        public void Finally(string refCode)
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            Description += $" کد پیگیری : {refCode}";
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }
    }
}

using HRM.Utils;

namespace HRM
{
    public class Bank
    {
        private float budget;
        private string bankDataFilePath;

        public float Budget
        {
            get { return budget; }
            private set { budget = value; }
        }

        public Bank(float initialBudget, string bankDataFilePath)
        {
            Budget = initialBudget;
            this.bankDataFilePath = bankDataFilePath;

            LoadData();
        }

        public void AddToBudget(float amount)
        {
            Budget += amount;

            SaveData();
        }

        public void DeductFromBudget(float amount)
        {
            if (amount > Budget)
                throw new InvalidOperationException("Insufficient budget.");

            Budget -= amount;

            SaveData();
        }

        private void SaveData()
        {
            DataStorage<Bank>.SaveData(bankDataFilePath, this);
        }

        private void LoadData()
        {
            if (DataStorage<Bank>.LoadData(bankDataFilePath).Count > 0)
            {
                Budget = DataStorage<Bank>.LoadData(bankDataFilePath).FirstOrDefault().Budget;
            }
        }
    }
}

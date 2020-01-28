package polymorphism;

public class VipCustomer extends Customer
{
    private int agentID;
    double saleRatio;
    public VipCustomer(int customerId, String customerName, int agentID)
    {
        super(customerId, customerName);

        customerGrade = "VIP";
        bonusRatio = 0.05;
        saleRatio = 0;
        this.agentID = agentID;
    }

    public int calPrice(int price)
    {
        bonusPoint += price * bonusPoint;

        return price  (int)(price*saleRatio)
    }
}
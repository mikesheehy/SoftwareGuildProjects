using System.Collections.Generic;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IOrderRepository
    {
        void DeleteFile(string orderDate);
        Order DisplayLoadOrder(string orderDate, int orderNumber);
        int GenerateOrderNumber(Order neworder);
        List<Order> GetAllDisplayOrders(string orderDate);
        List<Order> GetAllExistingOrders(Order neworder);
        List<Order> GetAllNonDeletedOrders(string orderDate, int orderNumber);
        List<Order> GetAllOrders(string orderDate);
        string GetFilePath(string orderDate);
        Order LoadOrder(string orderDate, int orderNumber);
        void NewOrderFile(Order neworder);
        void OverwriteExistingFile(List<Order> orders, Order neworder);
        void OverwriteFile(List<Order> orders, string orderDate);
        void UpdateOrder(Order orderToUpdate, string orderDate);
    }
}
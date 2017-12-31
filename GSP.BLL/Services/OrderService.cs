﻿using System.Collections.Generic;
using System.Linq;
using GSP.BLL.Services.Contracts;
using GSP.DAL.UnitOfWork.Contracts;
using GSP.Domain.Games;
using GSP.Domain.Orders;

namespace GSP.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGameStoreUnitOfWork _unitOfWork;

        public OrderService(IGameStoreUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrder(Order order)
        {
            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.Commit();
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Commit();
        }

        public void DeleteOrder(int orderId)
        {
            _unitOfWork.OrderRepository.Delete(orderId);
            _unitOfWork.Commit();
        }

        public void AddGameToBucket(OrderGame game)
        {
            _unitOfWork.OrderRepository.AddGameToBucket(game);
            _unitOfWork.Commit();
        }

        public void DeleteGameFromBucket(OrderGame game)
        {
            _unitOfWork.OrderRepository.DeleteGameFromBucket(game.OrderGameId);
            _unitOfWork.Commit();
        }

        public IEnumerable<Game> GetGameFromBucket(int customerId)
        {
            var order = _unitOfWork.OrderRepository.GetCurrentCustomerOrder(customerId);
            return order.Games.Select(x => x.Game).AsEnumerable();
        }

        public IEnumerable<Game> GetCustomerGames(int customerId)
        {
            return _unitOfWork.GameRepository
                .GetItems(x => x.Orders.Any(p => p.Order.CustomerId == customerId))
                .AsEnumerable();
        }

        public IEnumerable<Order> GetCustomerOrders(int customerId)
        {
            return _unitOfWork.OrderRepository.GetCustomerOrders(customerId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _unitOfWork.OrderRepository.GetOrders();
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.IO;
using ExcelDataReader;
using System.Collections.Generic;
using Conferencia.Aplication.Interface;
using Conferencia.Aplication.DTO;
using System;

namespace Conferencia.Aplication.Servicos
{
    public class UploadExcelService : IUploadExcelService
    {
        public readonly IOrderMapping _orderMapping;

        public UploadExcelService(IOrderMapping OrderMapping)
        {
            _orderMapping = OrderMapping;
        }

        public void ReadExcel(IFormFile file)
        {
            var OrderListDto = new List<OrderDto>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                var reader = ExcelReaderFactory.CreateReader(stream);

                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                foreach (System.Data.DataTable table in result.Tables)
                {
                    foreach (System.Data.DataRow row in table.Rows)
                    {

                        OrderListDto.Add(GenerateOrderListDto(row));
                    }
                }
                _orderMapping.SaveToOrder(OrderListDto);
            }
        }

        private OrderDto GenerateOrderListDto(System.Data.DataRow row)
        {
            return new OrderDto
            {
                Codigo = Convert.ToString(row["Codigo"]),
                NomeDoConsumidor = Convert.ToString(row["Nome"]),
                Bebida = Convert.ToString(row["Bebida"]),
                Embalagem = Convert.ToString(row["Embalagem"]),
                Quantidade = Convert.ToInt32((double)row["Quantidade"])
            };
        }
    }
}



﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Astronomy.Data.EF.Models;

namespace Astronomy.Data.EF.Data
{
    public static class AstronomicalDataContextProceduresExtensions
    {
        public static AstronomicalDataContextProcedures GetProcedures(this AstronomicalDataContext context)
        {
            return new AstronomicalDataContextProcedures(context);
        }
    }

    public partial class AstronomicalDataContextProcedures
    {
        private readonly AstronomicalDataContext _context;

        public AstronomicalDataContextProcedures(AstronomicalDataContext context)
        {
            _context = context;
        }

        public async Task<pGetCountOfStarsInCoordinateRangeResult[]> pGetCountOfStarsInCoordinateRangeAsync(double? Xmin, double? Ymin, double? Zmin, double? Xmax, double? Ymax, double? Zmax, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Xmin",
                    Value = Xmin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Ymin",
                    Value = Ymin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Zmin",
                    Value = Zmin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Xmax",
                    Value = Xmax ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Ymax",
                    Value = Ymax ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Zmax",
                    Value = Zmax ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<pGetCountOfStarsInCoordinateRangeResult>("EXEC @returnValue = [dbo].[pGetCountOfStarsInCoordinateRange] @Xmin, @Ymin, @Zmin, @Xmax, @Ymax, @Zmax", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<HygDatum[]> pGetStarsInCoordinateRangeAsync(double? Xmin, double? Ymin, double? Zmin, double? Xmax, double? Ymax, double? Zmax, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Xmin",
                    Value = Xmin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Ymin",
                    Value = Ymin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Zmin",
                    Value = Zmin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Xmax",
                    Value = Xmax ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Ymax",
                    Value = Ymax ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                new SqlParameter
                {
                    ParameterName = "Zmax",
                    Value = Zmax ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Float,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<HygDatum>("EXEC @returnValue = [dbo].[pGetStarsInCoordinateRange] @Xmin, @Ymin, @Zmin, @Xmax, @Ymax, @Zmax", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}

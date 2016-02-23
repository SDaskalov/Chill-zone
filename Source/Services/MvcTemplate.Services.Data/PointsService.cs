namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ChillZone.Data.Common;
    using ChillZone.Services.Data;
    using MvcTemplate.Data.Models;

    public class PointsService : IPointsService
    {
        private readonly IDbRepository<Point> points;

        public PointsService(IDbRepository<Point> points)
        {
            this.points = points;
        }

        public Point Add(Point content)
        {
            this.points.Add(content);
            this.points.Save();
            return content;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZagsDbServerProject.Entities;
using ZagsDbServerProject.Interfaces;
using ZagsDbServerProject.Models;

namespace ZagsDbServerProject.Repositories
{
    public class AddressesRepository : GenericRepository<Addresses>, IAddressesRepository
    {
        public AddressesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> GetJoinedAddress(int addressID)
        {
            return await Task.FromResult(
                context.Addresses.Where(a => a.AddressID == addressID)
                .Join(
                    context.Villages,
                    addr => addr.VillageID,
                    vll => vll.VillageID,
                    (addr, vll) => new { addr, vll }
                ).Join(
                    context.CitiesDistricts,
                    advl => advl.addr.CityDistrictID,
                    ctds => ctds.CityDistrictID,
                    (advl, ctds) => new { advl, ctds }
                ).Join(
                    context.Regions,
                    avcd => avcd.advl.addr.RegionID,
                    rg => rg.RegionID,
                    (avcd, rg) => new { avcd, rg }
                ).Join(
                    context.Countries,
                    avcdr => avcdr.avcd.advl.addr.CountryID,
                    ctr => ctr.CountryID,
                    (avcdr, ctr) => new { avcdr, ctr }
                ).Select(
                    res => new
                    {
                        P = res.avcdr.avcd.advl.addr.AddressName.ToString() + " "
                        + res.avcdr.avcd.advl.vll.Name.ToString() ?? "" + " "
                        + res.avcdr.avcd.ctds.Name.ToString() + " "
                        + res.avcdr.rg.Name.ToString() + " "
                        + res.ctr.ShortName.ToString()
                    }
                ).FirstOrDefault().P
            ) ;
        }

        public override void InsertData(Addresses data)
        {
            // TODO Change address insertion method
            Villages? tempVillage = null;
            if (data.VillageID != null)
            {
                tempVillage = context.Villages.Where(v => v.VillageID == data.VillageID)?.FirstOrDefault();
            }
            data.FullAddress = data.AddressName
                            + ((tempVillage == null) ? "" : tempVillage.Name)
                            + context.CitiesDistricts
                            .Where(cd => cd.CityDistrictID == data.CityDistrictID).Select(res => new
                            {
                                res.Name
                            }).First().Name
                            + context.Regions
                            .Where(rg => rg.RegionID == data.RegionID).Select(res => new
                            {
                                res.Name
                            }).First().Name
                            + context.Countries
                            .Where(ctry => ctry.CountryID == data.CountryID).Select(res => new
                            {
                                res.ShortName
                            }).First().ShortName;
            context.Set<Addresses>().Add(data);
        }

        public override void UpdateData(Addresses data)
        {
            Villages? tempVillage = null;
            if (data.VillageID != null)
            {
                tempVillage = context.Villages.Where(v => v.VillageID == data.VillageID)?.FirstOrDefault();
            }
            data.FullAddress = data.AddressName + " "
                            + ((tempVillage == null) ? "" : tempVillage.Name)
                            + " " + context.CitiesDistricts
                            .Where(cd => cd.CityDistrictID == data.CityDistrictID).Select(res => new
                            {
                                res.Name
                            }).First().Name
                            + " " + context.Regions
                            .Where(rg => rg.RegionID == data.RegionID).Select(res => new
                            {
                                res.Name
                            }).First().Name
                            + " " + context.Countries
                            .Where(ctry => ctry.CountryID == data.CountryID).Select(res => new
                            {
                                res.ShortName
                            }).First().ShortName;
            context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public async Task<FullAddress> GetFullAddressByID(int addressID)
        {
            Addresses address = context.Addresses.Where(a => a.AddressID == addressID).FirstOrDefault();
            if (address != null)
            {
                return null;
            }
            var tempAddress = context.Villages.Where(a => a.VillageID == address.VillageID).FirstOrDefault();
            FullAddress ans = new()
            {
                Village = tempAddress == null ? "" : tempAddress.Name,
                CityDistrict = (
                    await Task.FromResult(
                        context.CitiesDistricts
                        .Where(a => a.CityDistrictID == address.CityDistrictID)
                        .FirstOrDefault())
                    ).Name,
                Region = (await context.Regions.FindAsync(address.RegionID).ConfigureAwait(false)).Name,
                Country = (await context.Countries.FindAsync(address.CountryID).ConfigureAwait(false)).ShortName
            };
            return ans;
        }
    }
}

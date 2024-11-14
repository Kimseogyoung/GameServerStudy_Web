using WebStudyServer.Base;
using WebStudyServer.Manager;
using WebStudyServer.Model.Auth;
using WebStudyServer.Repo;

namespace WebStudyServer.Component
{
    public class DeviceComponent : AuthComponentBase
    {
        public DeviceComponent(AuthRepo authRepo) : base(authRepo)
        {
        }

        public bool TryGetDevice(string idfv, out DeviceManager mgrDevice)
        {
            mgrDevice = null;

            var repoDevice = _authRepo.GetDevice(idfv);
            if (repoDevice == null)
                return false;

            mgrDevice = new DeviceManager(_authRepo, repoDevice);
            return true;
        }

        public DeviceManager CreateDevice(string idfv)
        {
            var newDevice = new DeviceModel
            {
                Key = idfv,
                Idfa = "",
                AccountId = _authRepo.RpcContext.AccountId,
                State = Proto.EDeviceState.ACTIVE,
                Country = "",
                GeoIpCountry = "",
                Language = ""
            };
            var repoDevice = _authRepo.CreateDevice(newDevice);
            var mgrDevice = new DeviceManager(_authRepo, repoDevice);
            return mgrDevice;
        }
    }
}

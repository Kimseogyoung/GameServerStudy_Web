using WebStudyServer.Base;
using WebStudyServer.Manager;
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
            var repoDevice = _authRepo.CreateDevice(new Model.Auth.DeviceModel { Idfv = idfv });// TODO:
            var mgrDevice = new DeviceManager(_authRepo, repoDevice);
            return mgrDevice;
        }
    }
}

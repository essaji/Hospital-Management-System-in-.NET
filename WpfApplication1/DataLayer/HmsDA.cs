using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;

namespace HMS.DataLayer
{
    public class HmsDA
    {
        hmsEntities hms;
        
        public HmsDA()
        {
            hms = new hmsEntities();

        }

        public Boolean isAuthenticated(String user,String pass)
        {
            var obj = hms.users.Where(x => (x.username == user && x.password == pass)).FirstOrDefault();

            if (obj == null) return false;
            return true;
        }
        public String getNurseNameByNid(long nid)
        {
            var obj = hms.employees.Where(x=> x.eid == (hms.nurses.Where(y=> y.nid == nid).FirstOrDefault(f=> f!=null).eid)).FirstOrDefault(first=> first!=null);
            return obj.firstname;
        }

        public void remove(indoor indo)
        {
            indoor i = hms.indoors.Where(x => x.ipid == indo.ipid).FirstOrDefault();
            hms.indoors.Remove(i);
            hms.SaveChanges();
        }

        public void remove(medicine med)
        {
            medicine m = hms.medicines.Where(x => x.mid == med.mid).FirstOrDefault();
            hms.medicines.Remove(m);
            hms.SaveChanges();
        }

        public List<category> getCategories()
        {
            return hms.categories.ToList();
        }

        public List<indoor> getIndoors()
        {
            return hms.indoors.ToList();
        }

        public List<patient> getMyPatients(doctor d)
        {
            return hms.patients.Where(x => (x.catid == d.catid && x.type == null)).ToList();
        }
        public List<indoor> getMyOldPatients(doctor d)
        {
            return hms.indoors.Where(x => (x.patient.did == d.did)).ToList();
        }
        public room getRoom(long? rid)
        {
            return hms.rooms.Where(x => x.rid == rid).FirstOrDefault();
        }
        public void updateIndoor(indoor modified)
        {
            indoor currentIndoor = hms.indoors.Where(x=> x.ipid == modified.ipid).FirstOrDefault();
            hms.Entry(currentIndoor).CurrentValues.SetValues(modified);
            hms.SaveChanges();
        }
        public void updatePrescription(prescription modified)
        {
            prescription currentPres = hms.prescriptions.Where(x => x.prid == modified.prid).FirstOrDefault();
            hms.Entry(currentPres).CurrentValues.SetValues(modified);
            hms.SaveChanges();
        }
        public doctor getDoctorByUid(long uid)
        {
            return hms.doctors.Where(x=> x.eid == (hms.employees.Where(y=> y.uid == uid).FirstOrDefault().eid)).FirstOrDefault();

        }
        public indoor getIndoorByPid(long? pid)
        {
            return hms.indoors.Where(x => x.pid == pid).FirstOrDefault();
        }

        public List<prescription> getMyPrescriptions(doctor d)
        {
            return hms.prescriptions.Where(x => x.did == d.did).ToList();
        }

        public List<patient> getPatientList()
        {
            return hms.patients.ToList();
        }

        public void remove(doctor d)
        {
            user user = hms.users.Where(x => x.uid == d.employee.user.uid).FirstOrDefault();
            hms.users.Remove(user);
            hms.SaveChanges();
        }
        public void remove(room r)
        {
            room ro = hms.rooms.Where(x => x.rid == r.rid).FirstOrDefault();
            hms.rooms.Remove(ro);
            hms.SaveChanges();
        }
        public void remove(patient p)
        {
            patient pat = hms.patients.Where(x => x.pid == p.pid).FirstOrDefault();
            hms.patients.Remove(pat);
            hms.SaveChanges();
        }
        
        public user getUser(String user,String pass)
        {
            return hms.users.Where(x=> (x.username == user && x.password == pass)).FirstOrDefault();
        }
      

        public List<room> getRooms()
        {
            return hms.rooms.ToList();
        }
        public List<doctor> getDoctors()
        {
            return hms.doctors.ToList();
        }

        public List<medicine> getMedicines()
        {
            return hms.medicines.ToList();
        }
        public void addPrescription(prescription p)
        {
            hms.prescriptions.Add(p);
            hms.SaveChanges();
        }
        public void addIndoor(indoor patIndoor)
        {
            hms.indoors.Add(patIndoor);
            hms.SaveChanges();
        }

        public void addPatient(patient p)
        {
            hms.patients.Add(p);
            hms.SaveChanges();
        }

        public void addRoom(room r)
        {
            hms.rooms.Add(r);
            hms.SaveChanges();
        }

        public void addUser(user u)
        {
            hms.users.Add(u);
            hms.SaveChanges();
        }

        public void addEmployee(employee e)
        {
            hms.employees.Add(e);
            hms.SaveChanges();
        }

        public long getUid(String username)
        {
            user u = (user) hms.users.Where(x => (x.username == username)).FirstOrDefault();
            return u.uid;
        }
        public doctor getDocByDid(long did)
        {
            return hms.doctors.Where(x => x.did == did).FirstOrDefault();
        }

        public void saveChanges()
        {
            hms.SaveChanges();
        }

        public void updatePatient(patient modified)
        {
            patient currentPat = hms.patients.Where(x=> modified.pid == x.pid).FirstOrDefault();
            hms.Entry(currentPat).CurrentValues.SetValues(modified);
            hms.SaveChanges();
        }

        public void updateDoctor(doctor doc)
        {
            doctor currentDoc = hms.doctors.Where(x => x.did == doc.did).FirstOrDefault();
            employee currentEmp = hms.employees.Where(x => x.eid == doc.eid).FirstOrDefault();
            user currentUser = hms.users.Where(x => x.uid == doc.employee.uid).FirstOrDefault();

            hms.Entry(currentDoc).CurrentValues.SetValues(doc);
            hms.Entry(currentEmp).CurrentValues.SetValues(doc.employee);
            hms.Entry(currentUser).CurrentValues.SetValues(doc.employee.user);

            hms.SaveChanges();
        }

        public void updateRoom(room modified)
        {
            room currentRoom = hms.rooms.Where(x=> x.rid == modified.rid).FirstOrDefault();
            hms.Entry(currentRoom).CurrentValues.SetValues(modified);
            hms.SaveChanges();
        }

        public List<nurse> getNurses()
        {
            return hms.nurses.ToList();
        }

        public nurse getNurseByUid(long uid)
        {
            return (from n in hms.nurses
                    from emp in hms.employees
                    where emp.uid == uid && emp.eid == n.eid
                    select n
                    ).FirstOrDefault(first => first != null);
        }

        public nurse getNurseByNid(long nid)
        {
            return hms.nurses.Where(x => x.nid == nid).FirstOrDefault();
        }

        public List<prescription> getPrecriptions()
        {
            return hms.prescriptions.ToList();
        }

        public List<indoor> getMyPatients(nurse n)
        {
            List<indoor> patients = hms.indoors.ToList();
            List<indoor> indoors = new List<indoor>();

            foreach(indoor indo in patients)
            {
                if (indo.room!=null && indo.room.nid == n.nid)
                    indoors.Add(indo);
            }

            return indoors;
        }

        public List<room> getMyRooms(nurse n)
        {
            return hms.rooms.Where(x => x.nid == n.nid).ToList();
        }

        public void updateNurse(nurse nur)
        {
            nurse currentNurse = hms.nurses.Where(x => x.nid == nur.nid).FirstOrDefault();
            employee currentEmp = hms.employees.Where(x => x.eid == nur.eid).FirstOrDefault();
            user currentUser = hms.users.Where(x => x.uid == nur.employee.uid).FirstOrDefault();
            
            hms.Entry(currentNurse).CurrentValues.SetValues(nur);
            hms.Entry(currentEmp).CurrentValues.SetValues(nur.employee);
            hms.Entry(currentUser).CurrentValues.SetValues(nur.employee.user);
            
            hms.SaveChanges();
        }

        public void remove(nurse n)
        {
            user user = hms.users.Where(x => x.uid == n.employee.user.uid).FirstOrDefault();
            hms.users.Remove(user);
            hms.SaveChanges();
        }
        

        public doctor addDoctor(doctor d)
        {
            hms.doctors.Add(d);
            hms.SaveChanges();
            doctor doc = hms.doctors.Where(x => x.did == d.did).FirstOrDefault();
            return doc;
        }

        public user getUser(string username)
        {
            return hms.users.Where(x => x.username == username).FirstOrDefault();
        }

        public void addNurse(nurse n)
        {
            hms.nurses.Add(n);
            hms.SaveChanges();
        }
        public void updateMedicine(medicine modified)
        {
            medicine currentMed = hms.medicines.Where(x => x.mid == modified.mid).FirstOrDefault();
            hms.Entry(currentMed).CurrentValues.SetValues(modified);
            hms.SaveChanges();
        }
        public void addMedicine(medicine med)
        {
            hms.medicines.Add(med);
            hms.SaveChanges();
        }
    }
}

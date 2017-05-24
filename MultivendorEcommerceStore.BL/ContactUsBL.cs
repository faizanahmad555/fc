using MultivendorEcommerceStore.DB.Model;
using MultivendorEcommerceStore.DB.ViewModel;
using MultivendorEcommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultivendorEcommerceStore.BL
{
    public class ContactUsBL
    {
        // ADD: New Contact Message(For Visitors on Front End Side)
        public void AddContactMessage(AddContactUsViewModel model)
        {
            IContactUsRepository contactRepo = new ContactUsRepository();
            ContactU contact = new ContactU();

            contact.ContactID = Guid.NewGuid();
            contact.FirstName = model.FirstName;
            contact.LastName = model.LastName;
            contact.Email = model.Email;
            contact.Message = model.Message;
            contact.CreatedOn = DateTime.Now;

            contactRepo.Create(contact);
        }


        // SHOW: All Contact Messages(For Admin Side)
        public IEnumerable<DisplayContactUsViewModel> ContactMessageList()
        {
            var contactRepo = new ContactUsRepository();
            var contactMessage = contactRepo.Retrive().ToList();

            return contactMessage.Select(c => new DisplayContactUsViewModel
            {
                ContactID = c.ContactID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Message = c.Message,
                CreatedOn = c.CreatedOn,
            });

        }


        // EDIT: Contact Message (For Admin Side)
        public EditContactUsViewModel EditContactMessage(Guid ContactID)
        {
            EditContactUsViewModel viewModel = new EditContactUsViewModel();

            var contactRepo = new ContactUsRepository();
            var contactMessage = contactRepo.Retrive().Where(s => s.ContactID == ContactID).FirstOrDefault();

            viewModel.ContactID = contactMessage.ContactID;
            viewModel.FirstName = contactMessage.FirstName;
            viewModel.LastName = contactMessage.LastName;
            viewModel.Email = contactMessage.Email;
            viewModel.Message = contactMessage.Message;

            return viewModel;
        }

        // EDIT: Save Edited Contact Message(For Admin Side)
        public void AddEditedContactMessage(EditContactUsViewModel viewModel)
        {
            var contactRepo = new ContactUsRepository();
            ContactU contact = new ContactU();

            contact.ContactID = viewModel.ContactID;
            contact.FirstName = viewModel.FirstName;
            contact.LastName = viewModel.LastName;
            contact.Email = viewModel.Email;
            contact.Message = viewModel.Message;

            contactRepo.Update(contact);
        }


        // DELETE: All Contact Messages (For Admin Side)
        public void DeleteContactMessage(Guid ContactID)
        {
            var contactRepo = new ContactUsRepository();
            contactRepo.Delete(ContactID);
        }


    }
}

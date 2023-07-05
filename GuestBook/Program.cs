

using GuestBook;

GuestLogic.WelcomeMessage();

var (guests, totalGuests, familiesWithGuestsCount) = GuestLogic.GetAllGuests();

GuestLogic.DisplayGuestList(familiesWithGuestsCount);

GuestLogic.DisplayGuestsCount(totalGuests);
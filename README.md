# DigitalInventorySystem
Small project I worked on for digitally tracking my Magic: the Gathering collection. Features the ability to add cards one by one or by various mass import methods such as clipboard import, mass entry textbox import or Deckbox.org formatted CSV files.

Application uses DataBindingObjects with an internal SQL database for storing cards. Collection tracker supports alternate versions of cards, conditions and foiling. Displays card price fetched via the TCGPlayer API (caching of prices not fully implemented). Also fetches and then caches images of the card directly via the Wizards of the Coast website.

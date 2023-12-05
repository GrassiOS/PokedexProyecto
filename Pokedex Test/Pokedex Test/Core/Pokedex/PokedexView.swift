//
//  PokedexView.swift
//  Pokedex Test
//
//  Created by Martin on 29/07/23.
//

import SwiftUI

struct PokedexView: View {
    
    @State var user: User
    
    @EnvironmentObject var pokedexViewModel: PokedexViewModel
    @State private var isScrolled: Bool = false
    @State var searchText = ""
    
    var body: some View {
        NavigationStack {
            VStack {
                //Pkedex and UserIMG
                HStack(spacing: 3) {

                    NavigationLink {
                        ProfileView(user: user)
                    } label: {
                        Image(user.img ?? "pkebtn")
                            .resizable()
                            .scaledToFill()
                            .frame(width: 28, height: 28)
                            .clipShape(Circle())
                            .padding(.trailing, 16)
                    }
                    Text("\(user.username)'s POKEDEX")
                        .font(.custom("GILROY-BOLD", size: 32))

                }
                .padding(.bottom)
                
                ScrollView {
                    
                    HStack {
                        CustomSearchBarView(searchText: $searchText)
                        Button {
                            print("filter")
                        } label: {
                            FilterButtonView()
                        }
                    }
                    
                    LazyVStack(spacing: 2) {
                        ForEach(filteredPokemonList) { poke in
                            NavigationLink(destination:
                                            PokeInfoView(pokemon: poke, user: user)
                                           
                            ) {
                                PookemonConteinerView(poke: poke)
                            }
                        }
                    }
                }
            }
        }
    }
    
    var filteredPokemonList: [Pokemon] {
        if searchText.isEmpty {
            return pokedexViewModel.pokemonList
        } else {
            return pokedexViewModel.pokemonList.filter { $0.name.lowercased().contains(searchText.lowercased()) }
        }
    }
}
            

struct PokedexView_Previews: PreviewProvider {
    static var previews: some View {
        PokedexView(user: User.MOCK_USERS[1])
    }
}

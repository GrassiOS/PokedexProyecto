//
//  PodexViewPreview.swift
//  Pokedex Test
//
//  Created by Martin on 20/11/23.
//

import SwiftUI


struct PodexViewPreview: View {
    private var pokemonList = Pokemon.MOCK_POKEMON
    @State var searchText = ""
    
    var body: some View {
        NavigationStack {
            VStack {
                HStack(spacing: 3) {

                    Button {
                        print("log out user")
                    } label: {
                        Image("pkebtn")
                            .resizable()
                            .scaledToFill()
                            .frame(width: 28, height: 28)
                            .clipShape(Circle())
                            .padding(.trailing, 16)
                    }
                    Text("POKEDEX")
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
                                            PookemonConteinerView(poke: poke)
                            ) {
                                PookemonConteinerView(poke: poke)
                            }
                        }
                    }
                }
            }
            
            // Button in the bottom right corner
            VStack {
                Spacer()
                HStack {
                    Spacer()
                    Button(action: {
                        // Your button action here
                        print("Bottom Right Button Tapped")
                    }) {
                        Image(systemName: "plus")
                            .padding()
                            .background(Color.blue)
                            .foregroundColor(.white)
                            .cornerRadius(8)
                    }
                    .padding()
                }
            }
        }
    }
    
    var filteredPokemonList: [Pokemon] {
        if searchText.isEmpty {
            return pokemonList
        } else {
            return pokemonList.filter { $0.name.lowercased().contains(searchText.lowercased()) }
        }
    }
}

struct PodexViewPreview_Previews: PreviewProvider {
    static var previews: some View {
        PodexViewPreview()
    }
}

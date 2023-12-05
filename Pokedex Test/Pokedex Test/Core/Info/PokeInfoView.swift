//
//  PokeInfoView.swift
//  Pokedex Test
//
//  Created by Martin on 28/07/23.
//


import SwiftUI

struct PokeInfoView: View {
    @State var pokemon: Pokemon
    
    @State var user: User
    
    var body: some View {
        ZStack {
            //Color
            Color.fromString(pokemon.color ?? "red")
                .ignoresSafeArea()
            //RoundedRectangle
            VStack {
                Text(zeros(id: pokemon.id))
                    .font(.custom("GILROY-BOLD", size: 80))
                    .foregroundColor(.white
                        .opacity(0.7))
                    .alignmentGuide(HorizontalAlignment.center) { d in
                        d[.trailing] - 160
                    }
                Spacer()
                RoundedRectangle(cornerRadius: 40)
                    .foregroundColor(.white)
                    .frame(width: UIScreen.main.bounds.size.width,height: UIScreen.main.bounds.size.height*0.75)
                    .shadow(color: .gray.opacity(0.3), radius: 18)
            }
            .ignoresSafeArea(edges: .bottom)
            //Info
            VStack {
                AsyncImage(url: URL(string: pokemon.img ?? "")) { phase in
                    switch phase {
                    case .empty:
                        ProgressView()
                    case .success(let image):
                        image
                            .resizable()
                            .scaledToFill()
                            .frame(width: 190, height: 190)
                            .shadow(color: .gray.opacity(0.2), radius: 12)
                    case .failure:
                        Image("mr mime") // You can provide a placeholder image here
                            .resizable()
                            .scaledToFill()
                            .frame(width: 190, height: 190)
                    @unknown default:
                        Image("mr mime") // You can provide a placeholder image here
                            .resizable()
                            .scaledToFill()
                            .frame(width: 150, height: 150)
                    }
                }
                .padding(.top)
                //Name and Type (icon)
                
                HStack {
                    Text(pokemon.name.capitalized)
                        .font(.custom("GILROY-BOLD", size: 38))
                    
                    Image(pokemon.type?.name ?? "fire")//poke.type.image
                        .resizable()
                        .scaledToFill()
                        .frame(width: 15,height: 15)
                }
                .padding(.bottom,2)
                
                //hp (icon) and hp
                HStack {
                    Image(systemName: "heart.fill")
                        .foregroundColor(.red)
                    
                    Text("\(pokemon.hp) HP")
                        .font(.custom("GILROY-MEDIUM", size: 15))
                }
                .padding(.bottom,10)
                //Attack - Speed - Defense
                
                HStack {
                    VStack {
                        Image(systemName: "oar.2.crossed")
                            .foregroundColor(.gray)
                            .padding(.bottom,2)
                        
                        Text("\(pokemon.attack)")
                            .font(.custom("GILROY-MEDIUM", size: 15))
                    }
                    .frame(width: 50)
                    
                    VStack {
                        Image(systemName: "bolt.fill")
                            .foregroundColor(.yellow)
                            .padding(.bottom,2)
                        
                        Text("\(pokemon.speed)")
                            .font(.custom("GILROY-MEDIUM", size: 15))
                    }
                    .frame(width: 50)
                    
                    VStack {
                        Image(systemName: "shield.fill")
                            .foregroundColor(.blue)
                            .padding(.bottom,2)
                        
                        Text("\(pokemon.defense)")
                            .font(.custom("GILROY-MEDIUM", size: 15))
                    }
                    .frame(width: 50)
                    
                    
                }
                .padding(.bottom,20)
                
                //Description
                VStack(alignment: .leading, spacing: 4) {
                    Text("Description")
                        .modifier(TitleModifier())
                    
                    Text(pokemon.description ?? "cool")
                        .font(.custom("GILROY-MEDIUM", size: 15))
                        .frame(width: 305, alignment: .leading)
                }
                .padding(.bottom,50)
                HStack {
                    //type
                    TypeWeaknessView(title: "Type", type: pokemon.type ?? PokemonType(id: 0, name: "normal", img: "normal"))
                    Spacer()
                    //weakness
                    TypeWeaknessView(title: "Weakness", type: pokemon.weaknessType ?? PokemonType(id: 0, name: "normal", img: "normal"))
                }
                .frame(width: 333)
                .padding(.bottom,50)
                
                //Moves
                VStack(alignment:.leading,spacing: 4) {
                    Text("Moves")
                        .modifier(TitleModifier())
                        .padding(.horizontal,50)
                        .padding(.bottom)
                    
                    
                    if let items = pokemon.pokemonMoves {
                        LazyVGrid(columns: [
                            GridItem(.flexible(), spacing: 8),
                            GridItem(.flexible(), spacing: 8)
                        ], spacing: 10) {
                            ForEach(items, id: \.self) { move in
                                MoveView(move: move)
                            }
                        }
                    } else {
                        Text("No moves available")
                    }
                    
                }
                
                
                Spacer()
                Button {
                    if user.hasPokemon(poke: pokemon) {
                        print("Remove Pokemon from Collection Data")
                        user.removePokemon(poke: pokemon)
                        
                        Task { try await AuthService.shared.removePokemon(userID: user.id, pokeID: pokemon.id) }
                    } else {
                        // Pokemon is not in the collection, add it
                        print("Add Pokemon to Collection Data")
                        user.addPokemon(poke: pokemon)
                        
                        Task { try await AuthService.shared.addPokemon(userID: user.id, pokeID: pokemon.id) }
                    }
                } label: {
                    Image(user.hasPokemon(poke: pokemon) ? "pkebtnUnselect" : "pkebtn")
                        .resizable()
                        .frame(width: 20, height: 20)
                }
                
            }
            
        }
    }
}

struct PokeInfoView_Previews: PreviewProvider {
    static var previews: some View {
        PokeInfoView(pokemon: Pokemon.MOCK_POKEMON[2], user: User.MOCK_USERS[3])
    }
}


